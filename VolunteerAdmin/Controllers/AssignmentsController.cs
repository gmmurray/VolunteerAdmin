using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using VolunteerAdmin.Data;
using VolunteerAdmin.Models;

namespace VolunteerAdmin.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly AdminContext _context;

        public AssignmentsController(AdminContext context)
        {
            _context = context;
        }

        // GET: Assignments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assignments.ToListAsync());
        }

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Assignments/Create
        public async Task<IActionResult> Create(int id)
        {
            var Opportunity = await _context.Opportunities
                .Include(o => o.OppReqSkills)
                .ThenInclude(os => os.Skill)
                .FirstOrDefaultAsync(o => o.OpportunityID == id);

            var testVolunteers = _context.Volunteers
                .Include(tv => tv.VolunteerSkills)
                .ThenInclude(vs => vs.Skill);
                
                

            List<int> OppSkill = new List<int>();

            foreach(OppReqSkill ors in Opportunity.OppReqSkills)
            {
                OppSkill.Add(ors.SkillID);
            };

            List<Volunteer> Evolunteer = new List<Volunteer>();

            //I can't believe I figured this out. Praise me.
            foreach(Volunteer v in testVolunteers)
            {
                foreach(VolunteerSkill vs in v.VolunteerSkills)
                {
                    foreach(int skillID in OppSkill)
                    {
                        if (skillID.Equals(vs.SkillID))
                        {
                            Evolunteer.Add(v);
                        }
                    }
                }
            }


            ViewData["OpportunityName"] = Opportunity.OpportunityName;
            ViewData["OpportunityID"] = Opportunity;

            var AssignmentInfo = new AssignmentOpportunityViewModel
            {
                Volunteers = Evolunteer.ToList(),
                Opportunity = new Opportunity { OpportunityID = id}
                
            };

            return View(AssignmentInfo);
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentID,OpportunityID,VolunteerID")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentID,OpportunityID,VolunteerID")] Assignment assignment)
        {
            if (id != assignment.AssignmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.AssignmentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.AssignmentID == id);
        }
    }
}
