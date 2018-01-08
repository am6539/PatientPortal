using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortal.IRepository.CMS;
using PatientPortal.Domain.Models.CMS;
using PatientPortal.DataAccess.Repo.CMS;

namespace PatientPortal.Repositoty.CMS
{
    public class SliderRepoImpl : ISliderRepo
    {
        ISlider _slider;
        public SliderRepoImpl(ISlider slider)
        {
            this._slider = slider;
        }

        public async Task<Slider> SingleQuery(Dictionary<string, dynamic> para)
        {
            return await _slider.SingleQuery(para);
        }
        public async Task<IEnumerable<Slider>> Query(Dictionary<string, dynamic> para)
        {
            return await _slider.Query(para);
        }
        public async Task<bool> Transaction(Slider data, char action)
        {
            return await _slider.Transaction(data, action);
        }
        public async Task<bool> CheckExist(Dictionary<string, dynamic> para)
        {
            return await _slider.CheckExist(para);
        }
    }
}
