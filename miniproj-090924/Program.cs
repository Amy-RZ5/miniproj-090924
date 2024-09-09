Random rand = new Random();

bool DoesExist(int[,] mat)
{
    if (mat != null && mat.Length > 0)
        return true;
    return false;
}

int SaisieNombre()
{
    int n;
    Console.WriteLine("Ce nombre doit être positif");
    while (Int32.TryParse(Console.ReadLine(), out n) || n <= 0)
    {
        Console.WriteLine("should be positive integer");
        
    }

    return n;
}

int[,] InitMatrice(int ligne, int colonne)
{
    int[,] matrice = new int[3, 3];
    for (int i = 0; i < ligne; i++)
    {
        for (int j = 0; j < colonne; j++)
        {
            matrice[i, j] = rand.Next(1, 15);
        }
    }

    return matrice;
}

void Affichage(int[,] mat)
{
    if (DoesExist(mat))
    {
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                Console.Write(mat[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}


int NbValeursSup7(int[,] mat, int i0, int j0)
{
    //verifier que la matrice existe et est correcte
    if (!DoesExist(mat)) return -1;
    
    //n correspond au nombre de valeurs voisine supérieures à 7
    int n = 0;
    
    //On parcours l'ensemble de la matrice.
    for (int i = i0 - 1; i <= i0 + 1; i++)
    {
        for (int j = j0 - 1; j <= j0 + 1; j++)
        {
            //Verficication que la case du tableau est bien dans la matrice
            if (i < 0 || j < 0 || i >= mat.GetLength(0) || j >= mat.GetLength(1) || (i == i0 && j == j0)) continue;
            
            //Si la case qui est verifier à une valeur supperieur à 7, rajouter 1 au compteur.
            if (mat[i, j] >= 7) n++;
        }
    }
    
    //Netourner le nombre de case au tour avec une valeur de 7 ou +
    return n;
}


// main
int i = 1;
int nbIterations = 0;
Console.WriteLine("Entrez le nombre de lignes de la matrice");
int ligne = SaisieNombre();
Console.WriteLine("Entrez le nombre de colonnes de la matrice");
int colonne = SaisieNombre();

int[,] matrice = InitMatrice(ligne, colonne);

Console.WriteLine("Combien de fois voulez-vous tenter de corriger la matrice ?");
nbIterations = SaisieNombre();

Console.WriteLine("Voici votre matrice de début :\n");
Affichage(matrice);

while (i <= nbIterations)
{
    Console.WriteLine($"C'est votre {i}e itération");
    // insérer fonction correction calcul
    // petite animation pour le calcul ?

    Console.WriteLine("Voici votre matrice corrigée :");
    Affichage(matrice); // à voir si tu veux modifier le nom du tableau
    Console.WriteLine("Appuyez sur une touche pour afficher une nouvelle itération");
    Console.ReadKey();
    i++;
}

