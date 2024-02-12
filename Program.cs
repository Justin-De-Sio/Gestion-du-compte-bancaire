namespace Gestion_du_compte_bancaire;

// Created by DE SIO Justin and ROBERT Thomas
// TP of Microsoft C#
// 12-02-2024
// 

public interface IAfficher
{
    public void Afficher();
}

public class Client : IAfficher
{
    public string CIN { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Tel { get; set; }

    public Client()
    {
        this.CIN = "";
        this.Nom = "";
        this.Prenom = "";
        this.Tel = "";
    }

    public Client(string cin, string nom, string prenom, string tel)
    {
        CIN = cin;
        this.Nom = nom;
        this.Prenom = prenom;
        this.Tel = tel;
    }

    public Client(Client c)
    {
        this.CIN = c.CIN;
        this.Nom = c.Nom;
        this.Prenom = c.Prenom;
        this.Tel = c.Tel;
    }


    public void Afficher()
    {
        Console.WriteLine($"Client : CIN= {CIN}\n\t nom= { Nom } \n\t prenom= {Prenom}\n\t tel= {Tel}");
    }
}

public class Compte : IAfficher
{
    private double solde;
    private int id;
    public Client Client;
    private static int compteur = 0;
    
    public double Solde => solde;
    public int Id => id;

    public Compte()
    {
        compteur++;
        id = compteur;
    }

    public Compte(double solde, Client client) : this()
    {
        this.solde = solde;
        this.Client = client;
    }

    public Compte(Compte compte) : this()
    {
        this.Client = compte.Client;
        this.solde = compte.solde;
        this.id = compte.id;
    }


    public void Crediter(double solde)
    {
        this.solde += solde;
    }

    public void Crediter(double solde, Compte compte)
    {
        this.solde += solde;
        compte.Debiter(solde);
    }

    public void Debiter(double solde)
    {
        this.solde -= solde;
    }

    public void Debiter(double solde, Compte compte)
    {
        this.solde -= solde;
        compte.Crediter(solde);
    }

    public void Afficher()
    {
        Console.WriteLine($"Compte : Client= {Client} \n\t Solde= {solde} \n\t id={id} \n\t Nombre de compte= {compteur}.");
    }

    public int NumberOfAcount()
    {
        return id;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Client thomas = new Client("azert", "ROBERT", "Thomas", "+1234567890");
        Client justin = new Client("azerty", "DE SIO", "Justin", "+331234567890");
        
        thomas.Afficher();
        justin.Afficher();

        Compte a = new Compte(123, thomas);
        Compte b = new Compte(123456, justin);
        a.Afficher();
        b.Afficher();
    }
}
