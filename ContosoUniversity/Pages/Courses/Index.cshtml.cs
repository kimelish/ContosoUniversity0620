﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get; set; }

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .ToListAsync();

            //Courses = await _context.Courses.Select(c => new CourseVM
            //{
            //    CourseID = c.CourseID,
            //    Title = c.Title,
            //    Credits = c.Credits,
            //    DepartmentName = c.Department.Name
            //}).ToListAsync();
        }
    }
}