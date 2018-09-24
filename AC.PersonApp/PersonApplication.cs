using AC.Domain;
using AC.Infrastruture.Repositories.Contracts;
using AC.PersonApp.Contract;
using AC.PersonApp.DataTransferObject;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AC.PersonApp
{
    public class PersonApplication : IPersonApplication
    {
        readonly IPersonLegalRepository _personLegalRepository;
        readonly IPersonPhysicalRepository _personPhysicalRepository;

        public PersonApplication(IPersonLegalRepository personLegalRepository , IPersonPhysicalRepository personPhysicalRepository)
        {
            _personLegalRepository = personLegalRepository;
            _personPhysicalRepository = personPhysicalRepository;
        }

        public IEnumerable<PersonLegal> GetAllPersonLegal()
        {
            return _personLegalRepository.GetAsync().Result;
        }

        public IEnumerable<PersonPhysical> GetAllPersonPhysical()
        {
            return _personPhysicalRepository.GetAsync().Result;
        }

        public PersonLegal PostPersonLegal(PersonLegal person)
        {
            _personLegalRepository.Begin();
            _personLegalRepository.Save(person);
            _personLegalRepository.Commit();
            return person;
        }

        public PersonPhysical PostPersonPhysical(PersonPhysical person)
        {
            _personPhysicalRepository.Begin();
            _personPhysicalRepository.Save(person);
            _personPhysicalRepository.Commit();
            return person;
        }

        public int PostPersonPhysicaORPersonLegal(PersonLegalDTO personLegalDTO, PersonPhysicalDTO personPhysicalDTO)
        {
            if (personLegalDTO != null && personPhysicalDTO != null)
            {
                throw new Exception("Só deve existir uma pessoa para o cadastro continuar!");
            }

            if (personLegalDTO == null && personPhysicalDTO == null)
            {
                throw new Exception("É necessario informar uma pessoa fisica ou juridica para continuar!");
            }

            try
            {
                if (personLegalDTO != null)
                {

                    PersonLegal personLegal = new PersonLegal();
                    personLegal.Document = personLegalDTO.Document;
                    personLegal.FantasyName = personLegalDTO.FantasyName;
                    personLegal.SocialReason = personLegalDTO.SocialReason;

                    return PostPersonLegal(personLegal).Id;

                } else {

                    PersonPhysical personPhysical = new PersonPhysical();
                    personPhysical.Document = personPhysicalDTO.Document;
                    personPhysical.FullName = personPhysicalDTO.FullName;
                    personPhysical.Birth = personPhysicalDTO.Birth;

                    return PostPersonPhysical(personPhysical).Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
