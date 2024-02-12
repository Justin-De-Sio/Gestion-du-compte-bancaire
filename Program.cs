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
        Console.WriteLine($"Client : \n\t CIN={CIN}\n\t nom= { Nom } \n\t prenom={Prenom}\n\t tel= {Tel}");
    }
}

public class Compte : IAfficher
{
    private double solde;
    private int id;
    public Client client;
    
    public double Solde => solde;
    public int Id => id;

    public Compte()
    {
        id++;
    }

    public Compte(double solde, Client client) : base()
    {
        this.solde = solde;
        this.client = client;
        // TODO numéro de compte
    }

    public Compte(Compte compte) : base()
    {
        this.client = compte.client;
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
        Console.WriteLine($"Compte Client= {client}, Solde= {solde}, id={id}.");
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
        
    }
}
