using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using beltexam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace beltexam.Controllers
{
    public class BeltExamController : Controller
    {

        private BeltExamContext _context;
       
        public BeltExamController(BeltExamContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
                int? loggedperson = HttpContext.Session.GetInt32("loggedPerson");
                if (loggedperson == null)
            {   
                return RedirectToAction("Index");
            }
            else
            {
                User LoggingIn = _context.users.SingleOrDefault(x => x.UserId == loggedperson);
                ViewBag.User = LoggingIn;
                var allIdeas = _context.ideas.Include(a =>a.Likers).Include(x => x.Writer).ThenInclude(a => a.LikedIdeas).ToList();
                ViewBag.ideas = allIdeas;
                return View();
            }
        }

        [HttpPost]
        [Route("addIdea")]
        public IActionResult AddIdea(Idea formData)
        {
                int? loggedperson = HttpContext.Session.GetInt32("loggedPerson");
                if (loggedperson == null)
            {   
                return RedirectToAction("Index");
            }
            else
            {
                Idea idea = new Idea 
                { 
                    IdeaData = formData.IdeaData,
                    UserId = (int) loggedperson,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,

                };
                _context.ideas.Add(idea);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }
       


        [HttpGet]
        [Route("like/{IdeaId}")]
        public IActionResult Like(int IdeaId)
        {
                int? loggedperson = HttpContext.Session.GetInt32("loggedPerson");
                if (loggedperson == null)
            {   
                return RedirectToAction("Index");
            }
            else
            {
                Likes liking = new Likes
                {
                    UserId = (int) loggedperson,
                    IdeaId = IdeaId,

                };
                _context.likes.Add(liking);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet]
        [Route("show/{UserId}")]
        public IActionResult ShowOne(int UserId)
        {
                int? loggedperson = HttpContext.Session.GetInt32("loggedPerson");
                if (loggedperson == null)
            {   
                return RedirectToAction("Index");
            }
            else
            {
                var showOne = _context.users.Where(x => x.UserId == UserId).Include(y => y.LikedIdeas).SingleOrDefault();
                ViewBag.showOne = showOne;
                return View();
            }
        }

        [HttpGet]
        [Route("showAll/{IdeaId}")]
        public IActionResult ShowAll(int UserId)
        {
                int? loggedperson = HttpContext.Session.GetInt32("loggedPerson");
                if (loggedperson == null)
            {   
                return RedirectToAction("Index");
            }
            else
            {
                var showAll = _context.ideas.Include(y => y.Likers).ToList();
                ViewBag.showOne = showAll;
                return View();
            }
        }
        [HttpGet]
        [Route("home")]
        public IActionResult Home()
        {
                int? loggedperson = HttpContext.Session.GetInt32("loggedPerson");
                if (loggedperson == null)
            {   
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }
       
    }
}
    