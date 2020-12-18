using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing_Project {
    public interface IPropertyListGenerator {
        string PropertyRetriever(List<int> countyQualifications, ArrayList county);
    }
}
