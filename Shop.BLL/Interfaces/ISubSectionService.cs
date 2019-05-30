using Shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    public interface ISubSectionService : IDisposable
    {
        IEnumerable<SubSectionDTO> GetSubSections();
        SubSectionDTO GetSubSection(int? id);
        void UpdateSubSection(int? id, SubSectionDTO subSection);
        void AddSubSection(SubSectionDTO subSection);
        void DeleteSubSection(int? id);
    }
}
