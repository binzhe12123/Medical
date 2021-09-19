using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Clinic.Repository
{
    public class RepositoryBase2
    {
        protected IDbConnection _dbClinic;
        protected IDbConnection _dbMedical;
        public RepositoryBase2()
        {
            string ClinicconnectionString = ConfigurationManager.ConnectionStrings["DBClinic"].ConnectionString;
            string MedicalcconnectionString = ConfigurationManager.ConnectionStrings["DBMedical"].ConnectionString;
            _dbClinic = new IDbConnection(ClinicconnectionString);
            _dbMedical = new IDbConnection(MedicalcconnectionString);
        }

    }
}
