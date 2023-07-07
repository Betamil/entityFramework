## RIBEYRON Hugo

# Entity Framework Core with React Web App

Cet application fonctionne avec le principe du Code First qui est une approche 
de développement logiciel où l'on écrit d'abord le code pour définir le comportement 
et la structure d'une application, puis on génère ensuite automatiquement la base de 
données correspondante. Cela signifie que la base de données est créée en fonction du 
code plutôt que d'établir un schéma de base de données préalable et de générer ensuite 
le code pour y accéder. Cette approche permet une plus grande flexibilité dans le développement,
car les modifications apportées au code peuvent être reflétées dans la base de données sans nécessiter 
de changements manuels.

Pour le projet, nous n'utiliserons pas le FluentAPI d'Entity Framework qui est une approche 
utilisée pour configurer et mapper les modèles d'entités avec la base de données.

Cependant, nous utiliserons l'approche par convention qui nous est fournie par Entity Framework et qui
configure automatiquement le modèle si aucune configuration explicite n'est fournie.
Les conventions sont des règles prédéfinies qui déterminent comment les entités et les relations sont mappées à la base de données

## Installation du projet

Pour commencer faire un clone du projet
```bash
git clone git@github.com:Betamil/entityFramework.git
```

## Installation des packages 
### Dotnet
```bash
dotnet tool install --global dotnet-ef
```

### Entity Framework 
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

### SQLite
```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

### Lancement du projet 
```bash
cd ReactWebApp
```
```bash
dotnet run
```

### En cas de problème avec la BDD
#### Jouer les scripts de migration :

```bash
dotnet ef database update
```

## Structure du projet 

Le projet est en deux partie distinct :

- Le **front** dans 'ClientApp'
- Le **backend** dans 'Controller' / 'Entity' / 'Migration'

### Frontend

Dans le dossier 'src' à la racine du dossier 'ClientApp' ce trouve le dossier component.

À l'intérieur de celui-ci nous trouverons nos deux composants 'Category' & 'Product'. Tout deux
contenant un fichier Add[nom_du_dossier] & [nom_du_dossier]. 

Les deux fichier correspondent à nos vues
que l'on peut retrouver dans la barre des tâches de l'application. 

Le mapping des routes se fait depuis le fichier '**AppRoutes.js**' :
```js
const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/categories',
        element: <Categories />
    },
    {
        path: '/addCategory',
        element: <AddCategory />
    },
    {
        path: '/products',
        element: <Products />
    },
    {
        path: '/addProduct',
        element: <AddProduct />
    }
];
```

Le lien entre notre front et nos controller Backend est fait dans le fichier '**setupProxy.js**' :
```js
const context = [
    "/Category",
    "/api/Product"
];
```

## Backend 
### Les controllers

Allez dans le dossier '**Controllers**'.

Les controllers sont marqué par les annotations suivantes :
```csharp
[Route("[controller]")]
[ApiController]
```

Et par l'extend de la classe abstraite 'ControllerBase' : 
```csharp
public class CategoryController : ControllerBase
```

### Les entitées
Allez dans le dossier '**Entity**'.

### DatabaseContext
Allez dans le dossier '**Conf**'

Le fichier de configuration de la database se caractérise par l'extend de la classe DbContext :
```csharp
public class DatabaseContext : DbContext
```

Il est aussi nécéssaire de déclarer les DbSet qui vont servir à EntityFramework pour la création de nos entitées :
```csharp
 ...
 public DbSet<Product> Products { get; set; }
 public DbSet<Category> Categories { get; set; }
 public DbSet<Customer> Customers { get; set; }
 ...
```

Ensuite, pour créer la BDD SQLite, il faut override la méthode '**OnConfiguring**' et dire le nom de notre BDD avec le chemin :
```csharp
protected override void OnConfiguring(DbContextOptionsBuilder options)
     => options.UseSqlite($"Data Source=northwind.db");
```

## Les migrations
Allez dans le dossier '**Migrations**', dans lequel on trouvera tout les script de migration généré pour le projet.

Pour générer un script de migration il faut utiliser cette commande :
```bash
dotnet ef migrations add [nom_du_script]
```

Ensuite il faudra jouer le script de migration à l'aide de la commande :
```bash
dotnet ef database update
```










