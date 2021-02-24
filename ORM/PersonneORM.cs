using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BidCardCoin
{
    class PersonneORM
    {

        public static PersonneViewModel getPersonne(int idPersonne)
        {
            PersonneDAO pDAO = PersonneDAO.getPersonne(idPersonne);
            PersonneViewModel p = new PersonneViewModel(pDAO.idPersonneDAO, pDAO.nomDAO, pDAO.prenomDAO, pDAO.telephoneDAO, pDAO.emailDAO);
            return p;
        }

        public static ObservableCollection<PersonneViewModel> listePersonnes()
        {
            ObservableCollection<PersonneDAO> lDAO = PersonneDAO.listePersonnes();
            ObservableCollection<PersonneViewModel> l = new ObservableCollection<PersonneViewModel>();
            foreach (PersonneDAO element in lDAO)
            {
                PersonneViewModel p = new PersonneViewModel(element.idPersonneDAO, element.nomDAO, element.prenomDAO, element.telephoneDAO, element.emailDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updatePersonne(PersonneViewModel p)
        {
            PersonneDAO.updatePersonne(new PersonneDAO(p.idPersonneProperty, p.nomProperty, p.prenomProperty, p.telephoneProperty, p.emailProperty));
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAO.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneViewModel p)
        {
            PersonneDAO.insertPersonne(new PersonneDAO(p.idPersonneProperty, p.nomProperty, p.prenomProperty, p.telephoneProperty, p.emailProperty));
        }
    }
}
