using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtomHealth.Areas.Identity.Data;
using AtomHealth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AtomHealth.Data
{
    public class AtomHealthDBContext : IdentityDbContext<AtomHealthUser>
    {
        public AtomHealthDBContext(DbContextOptions<AtomHealthDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<MedicalCoverage> MedicalCoverage { get; set; }
        public DbSet<Immunization> Immunization { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<PatientCountryRecord> PatientCountryRecord { get; set; }

        public DbSet<PatientProvinceRec> PatientProvinceRec { get; set; }

        public DbSet<PatientImmunizationRec> PatientImmunizationRec { get; set; }

        public DbSet<PatientMedicalHistoryRec> PatientMedicalHistoryRec { get; set; }
        public DbSet<MedicalHistory> MedicalHistory { get; set; }

        public DbSet<CurrentMedicalCondition> CurrentMedicalCondition { get; set; }
        public DbSet<CurrentMedicalConditionRec> CurrentMedicalConditionRec { get; set; }
        public DbSet<PastMedicalHistory> PastMedicalHistory { get; set; }

        public DbSet<PastMedicalHistoryRec> PastMedicalHistoryRec { get; set; }
        public DbSet<FamilyMedicalHistory> FamilyMedicalHistory { get; set; }
        public DbSet<FamilyMedicalHistoryRec> FamilyMedicalHistoryRec { get; set; }
        public DbSet<CovidHistory> CovidHistory { get; set; }
        public DbSet<CovidHistoryRec> CovidHistoryRec { get; set; }
        public DbSet<Subscribe> Subscribe { get; set; }
        public object AtomHealthUser { get; internal set; }
        public object Data { get; internal set; }
    }
}
