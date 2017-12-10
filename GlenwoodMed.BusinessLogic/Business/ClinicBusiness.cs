using GlenwoodMed.Data;
using GlenwoodMed.Model;
using GlenwoodMed.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic
{
    public class ClinicBusiness : IClinicBusiness
    {
        #region GetAllClinics...
        public List<ClinicView> GetAllClinics()
        {
            using (var clinicrepo = new ClinicRepository())
            {
                return clinicrepo.GetAll().Select(x => new ClinicView()
                { ClinicId = x.ClinicId,
                    ClinicName = x.ClinicName
                }).ToList();
            }
        }
        #endregion

        #region GetClinicId...
        public ClinicView GetClinicId(int? id)
        {
            ClinicView cv = new ClinicView();

            using (var clinicrepo = new ClinicRepository())
            {
                Clinic _clinic = clinicrepo.GetById(id.Value);

                cv.ClinicId = _clinic.ClinicId;

                return cv;
            }
        }
        #endregion

        #region Details Method...
        public ClinicView DetailsMethod(int? id)
        {
            ClinicView cv = new ClinicView();

            using (var clinicrepo = new ClinicRepository())
            {
                if (id.HasValue && id != 0)
                {
                    Clinic _clinic = clinicrepo.GetById(id.Value);

                    cv.ClinicId = _clinic.ClinicId;
                    cv.ClinicName = _clinic.ClinicName;
                }

                return cv;
            }
        }
        #endregion

        #region CreateMethod...
        public void CreateMethod(ClinicView cv)
        {
            using(var clinicrepo = new ClinicRepository())
            {
                if(cv.ClinicId == 0)
                {
                    Clinic _clinic = new Clinic
                    {
                        ClinicId = cv.ClinicId,
                        ClinicName = cv.ClinicName
                    };

                    clinicrepo.Insert(_clinic);
                }
            }
        }
        #endregion

        #region GETeditMethod...
        public ClinicView GETeditMethod(int? id)
        {
            ClinicView cv = new ClinicView();

            using (var clinicrepo = new ClinicRepository())
            {
                if (id.HasValue && id != 0)
                {
                    Clinic _clinic = clinicrepo.GetById(id.Value);

                    cv.ClinicId = _clinic.ClinicId;
                    cv.ClinicName = _clinic.ClinicName;
                }

                return cv;
            }
        }
        #endregion

        #region PostEditMethod...
        public ClinicView PostEditMethod(ClinicView cv)
        {
            using (var clinicrepo = new ClinicRepository())
            {
                if (cv.ClinicId == 0)
                {
                    Clinic _clinic = new Clinic
                    {
                        ClinicId = cv.ClinicId,
                        ClinicName = cv.ClinicName
                    };

                    clinicrepo.Insert(_clinic);
                }

                else
                {
                    Clinic _clinic = clinicrepo.GetById(cv.ClinicId);

                    _clinic.ClinicId = cv.ClinicId;
                    _clinic.ClinicName = cv.ClinicName;

                    clinicrepo.Update(_clinic);
                }

                return cv;
            }
        }
        #endregion

        #region GETdeleteMethod...
        public ClinicView GETdeleteMethod(int id)
        {
            ClinicView cv = new ClinicView();

            using (var clinicrepo = new ClinicRepository())
            {
                if (id != 0)
                {
                    Clinic _clinic = clinicrepo.GetById(id);

                    cv.ClinicId = _clinic.ClinicId;
                    cv.ClinicName = _clinic.ClinicName;
                }

                return cv;
            }
        }
        #endregion

        #region PostDeleteMethod...
        public void PostDeleteMethod(int id)
        {
            using (var clinicrepo = new ClinicRepository())
            {
                if (id != 0)
                {
                    Clinic _clinic = clinicrepo.GetById(id);
                    clinicrepo.Delete(_clinic);
                }
            }
        }
        #endregion
    }
}
