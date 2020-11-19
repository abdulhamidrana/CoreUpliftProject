using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository.IRepository
{
    public interface IFrequencyRepositoy:IRepository<Frequency>
    {
        IEnumerable<SelectListItem> GetFrequencyListForDropDown();
        void Update(Frequency frequency);
    }
}
