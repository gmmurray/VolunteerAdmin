using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VolunteerAdmin.Data;
using VolunteerAdmin.Models;

namespace VolunteerAdmin.Controllers
{
    public class VolunteersController : Controller
    {
        private readonly AdminContext _context;

        public VolunteersController(AdminContext context)
        {
            _context = context;
        }

        // GET: Volunteers
        public async Task<IActionResult> Index(string filter)
        {
            var volunteers = from s in _context.Volunteers select s;

            //a.	Approved/Pending Approval (volunteers in both approval statuses are included)
            //            b.Approved
            //c.Pending Approval
            //d.Disapproved
            //e.Inactive
            //f.All
            //var search =>

            //switch (filter)
            //{
            //    case "Approved":
            //     {

            //            break;
            //     }
            //}
            //if (filter != null)
            //    return View("Delete");
           bool? filterBool;

            if(filter == "Approved")
            {
                filterBool = true;
            } else if(filter == "Disapproved")
            {
                filterBool = false;
            } else
            {
                filterBool = null;
            }

            if (!String.IsNullOrEmpty(filter))
            {
                volunteers = volunteers.Where(v => v.Approved == filterBool);
            }
            //else if(filter == "Pending")
            //{
            //    volunteers = volunteers.Where(v => v.Approved.Equals(null));
            //}


            return View(await volunteers.ToListAsync());
        }

        // GET: Volunteers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteers
                .Include(v => v.Assignments)
                .ThenInclude(a => a.Opportunity)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer);
        }

        // GET: Volunteers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Volunteers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Username,Password,HomePhone,CellPhone,WorkPhone,Address,Email,Education,EmergencyName,EmergencyHomePhone,EmergencyWorkPhone,EmergencyEmail,EmergencyAddress,DLCopyOnFile,SSCopyOnFile,Approved")] Volunteer volunteer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(volunteer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the program persists " +
                    "see your system administrator.");
            }
            return View(volunteer);
        }

        // GET: Volunteers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteers.FindAsync(id);
            if (volunteer == null)
            {
                return NotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ID,FirstName,LastName,Username,Password,HomePhone,CellPhone,WorkPhone,Address,Email,Education,EmergencyName,EmergencyHomePhone,EmergencyWorkPhone,EmergencyEmail,EmergencyAddress,DLCopyOnFile,SSCopyOnFile,Approved")] Volunteer volunteer)
        {
            //if (id != volunteer.ID)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(volunteer);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!VolunteerExists(volunteer.ID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(volunteer);
            if (id == null)
            {
                return NotFound();
            }
            var volunteerToUpdate = await _context.Volunteers.FirstOrDefaultAsync(v => v.ID == id);
            if (await TryUpdateModelAsync<Volunteer>(volunteerToUpdate,
                "",
                v => v.FirstName,
                v => v.LastName,
                v => v.Username,
                v => v.Password,
                v => v.HomePhone,
                v => v.CellPhone,
                v => v.WorkPhone,
                v => v.Address,
                v => v.Email,
                v => v.Education,
                v => v.EmergencyName,
                v => v.EmergencyHomePhone,
                v => v.EmergencyWorkPhone,
                v => v.EmergencyEmail,
                v => v.EmergencyAddress,
                v => v.DLCopyOnFile,
                v => v.SSCopyOnFile,
                v => v.Approved))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes." +
                        "Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(volunteerToUpdate);
        }

        // GET: Volunteers/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteers
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (volunteer == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(volunteer);
        }

        // POST: Volunteers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volunteer = await _context.Volunteers.FindAsync(id);
            //_context.Volunteers.Remove(volunteer);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            if (volunteer == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Volunteers.Remove(volunteer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool VolunteerExists(int id)
        {
            return _context.Volunteers.Any(e => e.ID == id);
        }
    }
}
