using Context;
using Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly MailService _mailService;  
        public LeadsController(AppDbContext context, MailService mailService)
        {
            _context = context;
            _mailService = mailService; 
        }

        [HttpGet(Name = "GetLead")]
        public ActionResult<IEnumerable<Lead>> GetLeadId(int status)
        {
            try
            {
                var leads = _context.Leads
                .Include(p => p.Category)
                .Where(e => e.Status == status) 
                .OrderByDescending(e => e.DateCreated)
                .ToList();

                return leads;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error List");
            }
        }


        [HttpPost]
        public ActionResult Post(Lead lead)
       {
            if (lead is null)
                return BadRequest();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Leads.Add(lead);
                    _context.SaveChanges();

                    transaction.Commit();

                    return StatusCode(StatusCodes.Status200OK, "Saved successfully");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error saving");
                }
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] int status)
        {
            try
            {
                var existingLead = _context.Leads.Find(id);

                if (existingLead == null)
                    return NotFound("Lead not found");
                

                if (existingLead.Price >= 500 && status == Convert.ToInt16(Status.Accepted))
                {
                    var descount = Convert.ToDouble(existingLead.Price) * 0.1;

                    existingLead.Price = existingLead.Price - Convert.ToDecimal(descount);    
                }

                if (status == Convert.ToInt16(Status.Accepted))
                {
                    existingLead.Status = Convert.ToInt16(Status.Accepted);
                    _mailService.sendEmail(existingLead);
                }
                   
                if(status == Convert.ToInt16(Status.Decline))
                    existingLead.Status = Convert.ToInt16(Status.Decline);

                
                _context.SaveChanges();

                return Ok(existingLead);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when updating");
            }

        }
    }
}
