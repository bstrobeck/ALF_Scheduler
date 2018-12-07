﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ALF_Scheduler
{
    class DataParser
    {
        // the facility name, licensee, license number,unit, address?city?, zipcode, number of beds, previous full inspection, most recent full inspection, inspection results 
        // proposed scheduling date, number of days and months between the last full inspection and the proposed scheduling date, what 15 months is from the last full inspection, 
        // what 18 months is from the last full inspection, number of licensors needed, sample size from last full inspection

        /*
        DatesOfSOD // dates of SOD (Statement of Deficiencies report) for substantiated complaints done since the last full inspection?
        EnforcementNotes  // any enforcement for any inspection done since the last full inspection? (fines, stop placement, conditions, revocation, summary suspension)
        FailedFollowUp
        Complaints  // failed follow-ups for current inspection or complaints*/

        Facility facility = new Facility();

        public Facility GetFacility() {
            return facility;
        }

        public void Name(string name) {
            facility.Name = name;
        }
        
        /// <summary>
        /// This method will split the licensee's name into first and last.
        /// </summary>
        /// <param name="licensee">The licensee's full name separated by a comma</param>
        public void Licensee(string licensee) {
            string[] firstLast = licensee.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            facility.LicenseeLastName = firstLast[0];
            facility.LicenseeFirstName = firstLast[1];
        }

        /// <summary>
        /// This method place the licensee's first and last names into their properties.
        /// </summary>
        /// <param name="licensee">The licensee's first and last names, respectively</param>
        public void Licensee(string first, string last) {
            facility.LicenseeFirstName = first;
            facility.LicenseeLastName = last;
        }

        public void Unit(string unit) {
            facility.Unit = Convert.ToChar(unit);
        }

        public void LicenseNumber(string number) {
            facility.LicenseNumber = Convert.ToInt32(number);
        }

        public void ZipCode(string zip) {
            facility.ZipCode = Convert.ToInt32(zip);
        }

        public void Address(string address) {
            facility.Address = address;
        }

        /// <summary>
        /// This method will check the incoming string against the regex
        /// pattern for dates, then create a DateTime object from the string.
        /// </summary>
        /// <param name="date">The date to be created</param>
        /// <returns>DateTime object</returns>
        /// <exception>Throws FormatException if date is not in the correct format</exception>
        public static DateTime CreateDateTime(string date) {
            Regex rx = new Regex("([0-9]|[0-9]{2})/([0-9]{2})/([0-9]{4}|[0-9]{2})");
            if (rx.IsMatch(date)) {
                return DateTime.Parse(date);
            } else {
                throw new FormatException("date does not match regex format");
            }
        }

        public void PreviousInspection(string date) {
            facility.LastFullInspection = CreateDateTime(date);
        }

        public void LastInspection(string date) {
            facility.MostRecentFullInspection = CreateDateTime(date);
        }

        public void ProposedDate(string date) {
            facility.ProposedDate = CreateDateTime(date);
        }

        public void NumberOfBeds(string beds) {
            facility.NumberOfBeds = Convert.ToInt16(beds);
        }
    }
}
