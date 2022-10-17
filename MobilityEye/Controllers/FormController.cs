using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;
using MobilityEye.Models;
using MobilityEye.ViewModels;
using Newtonsoft.Json;

namespace MobilityEye.Controllers
{
    public class FormController : Controller
    {
        private ApplicationDbContext _context;

        //using DI to auto inject db context.
        public FormController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Show All Avalible forms in the system
        [HttpGet]
        [Route("forms")]
        public IActionResult Index()
        {
            var forms = _context.Forms.ToList();
            return View("ViewForms",forms);
        }

        //show form create UI
        [HttpGet]
        [Route("forms/new")]
        public IActionResult Create()
        {
            return View();
        }

        //Forms saving Logic
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("forms/new")]
        public IActionResult Create(CreateFormViewModel model)
        {
            try
            {
                var json = JsonObject.Parse(model.JsonFormContent);
                var jform = json.Deserialize<Root>();

                var form = new Models.Form();
                form.Title = model.Title;

                foreach (var s in jform.form)
                {
                    var c = new FormControl();
                    c.Lable = s.label;
                    c.Type = s.type;


                    if (s.type == "radio" || s.type == "checkbox")
                    {
                        foreach (var options in s.options)
                        {
                            c.FormControlOptions.Add(new FormControlOption() { OptionLabel = options.ToString() });
                        }
                    }

                    form.FormControls.Add(c);
                }

                _context.Forms.Add(form);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Viewforms uploaded via JSON
        [HttpGet]
        [Route("forms/fill/{Id}")]
        public IActionResult FillForm(int id)
        {
            var form = _context.Forms.Include(x=>x.FormControls).ThenInclude(x=>x.FormControlOptions).SingleOrDefault(x => x.Id == id);
            if (form == null)
                return BadRequest();


            var model = new FillFormViewModel();
            

            return View(form);
        }



       
    }
}
