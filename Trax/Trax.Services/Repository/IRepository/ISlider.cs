using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface ISlider
    {
        List<Models.Slider> GetSlider();
        Models.Slider GetSlider(int id);
        Models.Slider CreateSlider(Models.Slider model);
        Models.Slider UpdateSlider(Models.Slider model);
        bool DeleteSlider(int id);
        Models.Slider FindSlider(int? slider);

    }
}
