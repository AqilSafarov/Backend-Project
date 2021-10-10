using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
   public  interface ITestimonial
    {
        List<Models.Testimonial> GetTestimonial();
        Models.Testimonial GetTestimonial(int id);
        Models.Testimonial CreateTestimonial(Models.Testimonial model);
        Models.Testimonial UpdateTestimonial(Models.Testimonial model);
        bool DeleteTestimonial(int id);
    }
}
