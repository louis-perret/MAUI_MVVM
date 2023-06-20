<h1 align="center">Master-Detail Leagye of Legend</h1>

Cette application vous permet d'accéder à un master-detail listant les champions disponibles au sein du jeu League of Legend.

## ✔️ Fonctionnalités

- [x] Lister les différents champions avec système de pagination
- [x] Afficher le détail d'un champion (nom, icon, image, description, caractéristiques et skills)
- [x] Modifier un champion (nom, icon, image, description, caractéristiques et skills) à partir du master comme du detail
- [x] Ajouter un champion
- [x] Supprimer un champion
- [ ] Implémentation d'un MVVM toolkit maison.
  - [x] Factorisation de l'implémentation de INotifyPropertyChanged
  - [x] Une BaseVM non générique 
  - [x] Une BaseVM avec propriété *Model* générique
  - [ ] Faire vérifier à Marc Chevaldonné

## 🖥️ Stack techniques

- C# ([API reference](https://learn.microsoft.com/fr-fr/dotnet/csharp/))
- .Net MAUI ([API reference](https://learn.microsoft.com/fr-fr/dotnet/maui/))
- Visual Studio ([API reference](https://learn.microsoft.com/fr-fr/visualstudio/windows/?view=vs-2022))

## ⚙️ How to run the app ?

> Ouvrer, sous Visual Studio, le fichier sources/LeagueOfLegends.sln, sélectionner comme projet de démarrage le projet Views, puis exécuter l'application.

## Comment j'ai structuré mon application

J'ai utilisé le patron [MVVM](https://learn.microsoft.com/fr-fr/windows/uwp/data-binding/data-binding-and-mvvm) pour architecturer mon application. Ce dernier me permet de découpler ma Vue de mon Modèle en ajoutant un intermédiaire qu'est la ViewModel. Je l'ai utilisé de cette manière :
- Implémentation de ViewModel dites "Wrapper" servant à envelopper en leur sein, un object du Modèle (pour ChampionVM, ce sera la classe Champion qui sera enveloppée)et exposant à la vue les données contenues dans ce modèle qui lui seront utiles. En effet, pour moi, ce type de ViewModel doit avant répondre aux besoins de la Vue. Pour ce faire, il se peut que je n'ai pas besoin d'exposer toutes les données contenues dans le modèle et même, ma ViewModel peut aussi contenir ses propres données à elles utiles à la fois Vue mais également à elle. Par exemple, ma ChampionVM contient une ObservableList static contenant toutes les classes possibles pour un champion. Cette propriété n'est en aucun cas contenu dans mon Champion modèle puisqu'il n'y a pas d'utilité certaine, cependant, ma vue en a besoin pour l'ajout et l'édition donc ma ViewModel doit lui permettre d'y avoir accès.
- Implémentation d'une ViewModel applicative. Cette dernière me sert à faire la liaison entre mes Vues et mes ViewModel wrappers en assurant la bonne navigation entre les différentes pages. Ainsi, cela simplifie la gestion de la navigation et des différents passages de paramètres qu'il peut y avoir tout en simplifiant le code behind des vues.
  
## 👤 Author

**PERRET Louis**

* Github: [@LouisPerret](https://github.com/louis-perret)
* LinkedIn: [@Louis Perret](https://fr.linkedin.com/in/louis-perret-a67a6321b)