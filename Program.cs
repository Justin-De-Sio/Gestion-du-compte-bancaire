namespace Gestion_du_compte_bancaire;

// Created by DE SIO Justin and ROBERT Thomas
// TP of Microsoft C#
// 12-02-2024
// 

public interface IAfficher
{
    public void Afficher();
}
/// <summary>
/// Class permettant de créer un Client
/// </summary>
public class Client : IAfficher
{
    public string CIN { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Tel { get; set; }
    
    /// <summary>
    /// Constructeur par defaut
    /// </summary>
    public Client()
    {
        this.CIN = "";
        this.Nom = "";
        this.Prenom = "";
        this.Tel = "";
    }
    
    /// <summary>
    /// Constructeur paramétré
    /// </summary>
    /// <param name="cin">Carte National d'Identité</param>
    /// <param name="nom">Nom du client</param>
    /// <param name="prenom">Prénom du client</param>
    /// <param name="tel">Numéro de téléphone
    /// </param>
    public Client(string cin, string nom, string prenom, string tel)
    {
        CIN = cin;
        this.Nom = nom;
        this.Prenom = prenom;
        this.Tel = tel;
    }

    /// <summary>
    /// Constructeur par copie
    /// </summary>
    /// <param name="c">Client à copier</param>
    public Client(Client c) : this(c.CIN, c.Nom, c.Prenom, c.Tel)
    {
    }


    /// <summary>
    /// Méthode permettant d'afficher un client
    /// </summary>
    public void Afficher()
    {
        Console.WriteLine($"Client : CIN= {CIN}\n\t nom= {Nom} \n\t prenom= {Prenom}\n\t tel= {Tel}");
    }
}

/// <summary>
/// Classe permettant de créer des comptes bancaire
/// </summary>
public class Compte : IAfficher
{
    private double solde;
    private int id;
    public Client Client { get; }
    private static int compteur = 0;

    public double Solde
    {
        get => solde;
    }

    public int Id
    {
        get => id;
    }

    /// <summary>
    /// Constructeur par defaut avec incrémentation de l'identifiant et du nombre de compte
    /// </summary>
    public Compte()
    {
        Compteur.Increment();
        id = Compteur.NombreDeCompte;
    }

    /// <summary>
    /// Constructeur paramêtré
    /// </summary>
    /// <param name="solde">Sole du client</param>
    /// <param name="client">Client créant le compte</param>
    public Compte(double solde, Client client) : this()
    {
        this.solde = solde;
        this.Client = client;
    }

    /// <summary>
    /// Constructeur par copie
    /// </summary>
    /// <param name="compte">Compte à copier</param>
    public Compte(Compte compte) : this()
    {
        this.Client = compte.Client;
        this.solde = compte.solde;
        this.id = compte.id;
    }


    /// <summary>
    /// Méthode interne à la classe afin de créditer un solde
    /// </summary>
    /// <param name="solde">solde à ajouter</param>
    private void Crediter(double solde)
    {
        this.solde += solde;
    }

    /// <summary>
    /// Méthode permettant à un utilisateur créditeur de réaliser une transaction avec un autre compte
    /// </summary>
    /// <param name="solde">solde à créditer</param>
    /// <param name="compte">compte à débiter</param>
    public void Crediter(double solde, Compte compte)
    {
        if (this.solde >= solde)
        {
            this.Debiter(solde);
            compte.Crediter(solde);
        }
        else
        {
            Console.WriteLine("Solde insuffisant");
        }
    }

    /// <summary>
    /// Méthode interne à la classe afin de débiter un solde
    /// </summary>
    /// <param name="solde">solde à soustraire</param>
    private void Debiter(double solde)
    {
        this.solde -= solde;
    }

    /// <summary>
    /// Méthode permettant à un utilisateur débiteur de réaliser une transaction avec un autre compte
    /// </summary>
    /// <param name="solde">solde à débiter</param>
    /// <param name="compte">compte à créditer</param>
    public void Debiter(double solde, Compte compte)
    {
        this.solde -= solde;
        compte.Crediter(solde);
    }

    /// <summary>
    /// Méthode permettant d'afficher un compte
    /// </summary>
    public void Afficher()
    {
        Console.WriteLine(
            $"Compte : Client= {Client} \n\t Solde= {solde} \n\t id={id} \n\t");
    }

    /// <summary>
    /// Retourne le nombre de compte
    /// </summary>
    /// <returns>Nombre de compte</returns>
    public int NumberOfAcount()
    {
        return id;
    }
}

public static class Compteur
{
    public static int NombreDeCompte { get; set; }

    public static void Increment()
    {
        NombreDeCompte++;
    }
    
    public static void Decrement()
    {
        NombreDeCompte--;
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

        Compte c = new Compte(1234, thomas);
        c.Afficher();

        a.Crediter(100, b);

        a.Afficher();
        b.Afficher();

        // Permet de tester la création d'un compte par copie et d'afficher les différents en compte en cas de modification
        Compte d = new Compte(c);
        d.Crediter(1000, a);
        d.Afficher();
        c.Afficher();
        a.Afficher();
        
        Console.WriteLine("Nombre de compte : " + Compteur.NombreDeCompte);
    }
}