using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CFA_CORE.Data;
using CFA_CORE.Models;
using CFA_CORE.Utilities;
using NToastNotify;

namespace CFA_CORE.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IToastNotification _toastNotification;
        private readonly CustomerDbContext _context;

        public CustomersController(ILogger<CustomersController> logger, IToastNotification toastNotification, CustomerDbContext context)
        {
            _context = context;
            _toastNotification = toastNotification;
            _logger = logger;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Customers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Cust_Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cust_Id,Cust_Name,Cust_Age,OrderdDate,Cust_DOB,Cust_MobileNo,Cust_Email,Cust_Password,Cust_ConfirmPassword")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //EncryptDecrypt
                customer.Cust_Password=EncryptDecrypt.Encrypt(customer.Cust_Password);
                _context.Add(customer);   
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Details created successfully");
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cust_Id,Cust_Name,Cust_Age,OrderdDate,Cust_DOB,Cust_MobileNo,Cust_Email,Cust_Password,Cust_ConfirmPassword")] Customer customer)
        {
            if (id != customer.Cust_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //EncryptDecrypt
                    customer.Cust_Password = EncryptDecrypt.Encrypt(customer.Cust_Password);
                    
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddWarningToastMessage("Details Updated successfully");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Cust_Id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Cust_Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'CustomerDbContext.Customers'  is null.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            _toastNotification.AddErrorToastMessage("Details Deleted successfully");
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return _context.Customers.Any(e => e.Cust_Id == id);
        }
    }
}
