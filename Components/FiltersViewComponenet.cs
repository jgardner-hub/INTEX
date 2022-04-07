using INTEX.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX.Components
{
    public class FiltersViewComponent : ViewComponent
    {
        private CrashesDbContext _context { get; set; }

        public FiltersViewComponent(CrashesDbContext temp)
        {
            _context = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCounty = RouteData?.Values["county"];

            var county = _context.crashdata
                .Select(x => x.COUNTY_NAME)
                .Distinct()
                .OrderBy(x => x);

            return View(county);
        }

    }
}
