using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst;

public partial class Student
{
   public string FullName => Name + " " + Surname;
    
    }

