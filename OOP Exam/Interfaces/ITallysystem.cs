using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Models;

namespace OOP_Exam.Interfaces
{
    public interface ITallysystem
    {
        List<Product> Products { get; }
        List<User> Users { get; set; }
        BuyTransaction BuyProduct(User user, Product product, int count); //udfører den logik der køber et produkt på en brugers konto, ved brug af en transaktion
        InsertCashTransaction AddCreditsToAccount(User user, decimal amount); //indsætter et beløb på en brugers konto, via en transaktion.
        void ExecuteTransaction(Transaction transaction); //hjælpemetode til at eksekvere transaktioner, og sørge for at de bliver
        void DisplayLowFunds(User user, decimal balance);

        //tilføjet til en liste af udførte transaktioner.Hvis transaktionen altså ikke fejler.
        Product GetProductByID(int id); //Finder og returnerer det unikke produkt i listen over produkter ud fra et produkt-id. Der bliver
                                        //kastet en brugerdefineret exception hvis produktet ikke eksisterer. Denne exception
                                        //indeholder information om produkt og beskrivende besked.
        IEnumerable<User> GetUsers(Func<User, bool> predicate); //Brugere der overholder predicate
        User GetUserByUsername(string username);//Finder og returnerer den unikke bruger i brugerlisten ud fra brugernavn. Der bliver kastet en
                                                //brugerdefineret exception hvis brugeren ikke findes.Denne exception indeholder information
                                                //om bruger og beskrivende besked.
        IEnumerable<Transaction> GetTransactions(User user, int count); //Finder et angivet (via parameter) antal transaktioner relateret til en given specifik bruger.
                                                                        //Det er de nyeste transaktioner der findes.
        IEnumerable<Product> ActiveProducts(); //aktive produkter i stregsystemet på nuværende tidspunkt
        
        event User.UserBalanceNotification UserBalanceWarning;
    }
}