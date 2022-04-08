// See https://aka.ms/new-console-template for more information

/// RISPOSTE TEORIA ////
/// 1. a, b, e, g
/// 2. b, d
/// 3. c, f

// I nomi delle aree sono sigle (ad esempio ROS4) non sono aree geografiche esistenti

using Polizia;

Console.WriteLine("Benvenuto nell'archivio della Polizia!");

RepositoryAgentiDbADO repositoryAgenti = new RepositoryAgentiDbADO();


bool continua = true;
while (continua == true)
{
    Menu();
    int scelta = Scegli();

    switch (scelta)
    {
        case 1:
            // Mostra gli agenti di Polizia
            VisualizzaAgenti();
            break;
        case 2:
            // Mostra gli agenti assegnati ad una determinata area
            VisualizzaAgentiPerArea();
            break;
        case 3:
            // Mostra agenti rispetto agli anni di servizio
            VisualizzaAgentiPerAnniDiServizio();
            break;
        case 4:
            // Inserisci un nuovo agente
            // Controlla che non sia già presente attraverso il codice fiscale
            InserisciNuovoAgente();
            break;       
        case 0:
            Console.WriteLine("Ciao!");
            continua = false;
            break;
        default:
            Console.WriteLine("Scelta errata. Riprova.");
            break;
    }

}

void InserisciNuovoAgente()
{
    // Caratteristiche da richiedere all'utente
    // Nome, Cognome, CodiceFiscale, AreaGeografica, AnnoDiInizioAttivita
    
    Console.WriteLine("Inserisci il nome: ");
    string nome = Console.ReadLine();

    Console.WriteLine("Inserisci il cognome: ");
    string cognome = Console.ReadLine();
       

    bool valido;
    string codiceFiscale = null;
    do
    {
        Console.WriteLine("Inserisci codice fiscale valido/che non sia già presente");
        codiceFiscale = Console.ReadLine();
        valido = ControlloCF(codiceFiscale);

    } while (!(valido));   

    Console.WriteLine("Inserisci l'area geografica: ");
    string areaGeografica = (Console.ReadLine());

    string msg = "Inserisci l'anno di inizio attività: ";
    int annoDiInizioAttivita = InserisciNumeroPositivo(msg);

    var agente = new Agente(nome, cognome, codiceFiscale, areaGeografica, annoDiInizioAttivita);
    bool esito = repositoryAgenti.Aggiungi(agente);
    if (esito)
    {
        Console.WriteLine("Agente aggiunto correttamente");
    }
    else
    {
        Console.WriteLine("Errore. Non è stato possibile aggiungere!");
    }    
}

bool ControlloCF(string verificaCodice)
{
    if (repositoryAgenti.GetByCodiceFiscale(verificaCodice) == null)
    {
        return true;
    }
    else
    {
        return false;   
    }
}

void VisualizzaAgentiPerAnniDiServizio()
{
    string msg = "Inserisci il numero di anni di servizio desiderati";
    int anniDiServizio = InserisciNumeroPositivo(msg);

    var agentiArea = repositoryAgenti.GetByAnniDiServizio(anniDiServizio);
    if (agentiArea.Count == 0)
    {
        Console.WriteLine("Non sono presenti agenti con gli anni di servizio desiderati");
    }
    else
    {
        Console.WriteLine($"Tutti gli agenti di Polizia che hanno maturato almeno {anniDiServizio} anni di servizio sono: ");
        foreach (var item in agentiArea)
        {
            Console.WriteLine(item.ToString());
        }
    }
}

int InserisciNumeroPositivo(string msg)
{
    int numeroPositivo;
    do
    {
        Console.WriteLine(msg);        

    } while (!(int.TryParse(Console.ReadLine(), out numeroPositivo) && numeroPositivo>0));
    return numeroPositivo;
    
}

void VisualizzaAgentiPerArea()
{

    // TODO Mostrare all'utente le aree da cui scegliere

    // select distinct Agente.AreaGeografica
    // from Agente

    Console.WriteLine("Di quale area desideri visualizzare gli agenti? ");
    string area = Console.ReadLine();

    var agentiArea = repositoryAgenti.GetByArea(area);
    if (agentiArea.Count == 0)
    {
        Console.WriteLine("Non sono presenti agenti nell'area selezionata");
    }
    else
    {
        Console.WriteLine($"Tutti gli agenti di Polizia assegnati all'area {area} sono: ");
        foreach (var item in agentiArea)
        {
            Console.WriteLine(item.ToString());
        }
    }
    
}

void VisualizzaAgenti()
{
    var agenti = repositoryAgenti.GetAll();
    if (agenti.Count == 0)
    {
        Console.WriteLine("Lista vuota");
    }
    else
    {
        Console.WriteLine("Tutti gli agenti di Polizia sono: ");
        foreach (var item in agenti)
        {
            Console.WriteLine(item.ToString());
        }
    }
}

int Scegli()
{
    int sceltaUtente;
    do
    {
        Console.Write("Fai la tua scelta tra le possibili voci del menu: ");
    } while (!(int.TryParse(Console.ReadLine(), out sceltaUtente) && sceltaUtente>=0 && sceltaUtente<=4));
    return sceltaUtente;
}

void Menu()
{
    Console.WriteLine("-----------POLIZIA------------");
    Console.WriteLine("1. Mostra gli agenti di Polizia");
    Console.WriteLine("2. Mostra gli agenti assegnati ad una determinata area");
    Console.WriteLine("3. Mostra agenti rispetto agli anni di servizio");
    Console.WriteLine("4. Inserisci un nuovo agente");

    Console.WriteLine("0. Exit");
}






