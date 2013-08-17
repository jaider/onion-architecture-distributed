﻿using System;
using Core;
using CreditEngine.Commands;
using NServiceBus;

namespace CreditEngineHost
{
    public class CreditCardApplicationRepository : ICreditCardApplicationRepository
    {
        public void SaveApplicationFor(Applicant applicant)
        {
            var applyForCreditCommand = new ApplyForCreditCommand(Guid.NewGuid());
            applyForCreditCommand.ApplicantFirstName = applicant.FirstName;
            applyForCreditCommand.ApplicantLastName = applicant.LastName;
            applyForCreditCommand.ApplicantDateOfBirth = applicant.DateOfBirth;
            applyForCreditCommand.ApplicantSocialSecurityNumber = applicant.SocialSecurityNumber;

            IBus bus = BusContext.GetBus();

            bus.Send(applyForCreditCommand);
        }
    }
}