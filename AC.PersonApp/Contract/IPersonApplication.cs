using AC.Domain;
using AC.PersonApp.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace AC.PersonApp.Contract
{
    public interface IPersonApplication
    {

        int PostPersonPhysicaORPersonLegal(PersonLegalDTO personLegalDTO, PersonPhysicalDTO personPhysicalDTO);

    }
}
