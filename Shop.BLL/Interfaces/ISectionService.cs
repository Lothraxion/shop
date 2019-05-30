using Shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    public interface ISectionService : IDisposable
    {
        IEnumerable<SectionDTO> GetSections();
        SectionDTO GetSection(int? id);
        void UpdateSection(int? id, SectionDTO section);
        void AddSection(SectionDTO section);
        void DeleteSection(int? id);
    }
}
