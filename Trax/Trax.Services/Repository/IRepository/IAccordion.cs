using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface IAccordion
    {
        List<Models.Accordion> GetAccordion();
        Models.Accordion GetAccordion(int id);
        Models.Accordion CreateAccrodion(Models.Accordion model);
        Models.Accordion UpdateAccrodion(Models.Accordion model);
        bool DeleteAccordion(int id);


    }
}
