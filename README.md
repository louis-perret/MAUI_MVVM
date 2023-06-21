e<h1 align="center">Master-Detail League of Legend</h1>

Cette application vous permet d'accéder à un master-detail listant les champions disponibles au sein du jeu League of Legend.

Mon MVVM maison est disponible sur la branche *Master*. L'utilisation du toolkit n'a pas été réalisée.

## ✔️ Fonctionnalités

- [x] Lister les différents champions avec système de pagination
- [x] Afficher le détail d'un champion (nom, icon, image, description, caractéristiques et skills)
- [x] Modifier un champion (nom, icon, image, description, caractéristiques et skills) à partir du master (avec slide vers la gauche) comme du detail (bouton en haut à droite)
- [x] Ajouter un champion (bouton "+" en haut à droite du master)
- [x] Supprimer un champion (slide vers la gauche côté master)
- [x] Implémentation d'un MVVM toolkit maison.
  - [x] Factorisation de l'implémentation de INotifyPropertyChanged
  - [x] Une BaseVM non générique 
  - [x] Une BaseVM avec propriété *Model* générique
  - [x] Faire vérifier à Marc Chevaldonné

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

#### Utilisation du toolkit

Je ne l'ai pas utilisé dans ce projet mais si je l'avais utilisé, il m'aurait permis sans aucun doute d'écrire moins de ligne dans mes classes VM. En effet, ce dernier permet de factoriser pas mal de points communs entre les différentes VM que nous pouvons créer, comme le système de notification avec INotifyPropertyChange, le système de commande où, avec un simple décorateur au dessus d'une méthode, nous pouvons créer une commande automatiquement (et même la raffraichir automatiquement) sans devoir le faire à la main.

Bref, il est donc très intéressant de l'utiliser.

## Problèmes connus

- Problème d'icon qui ne correspond pas toujours au bon champion sous Android
- Navigation non fonctionnelle entre mes pages master/detail et ajout/édition d'un champion sous IOS (mais fonctionnelle sous Android !)
- Utilisation du FilePicker fais crash l'application sous l'émulateur Android Pixel 3 (et non sur l'émulateur Android Pixel 5)
- Sur la page du detail, le bouton modifier apparaît avec un "+" et non écrit "modifier" sous Android (s'affiche correctement sous IOS). En faite, l'icon du bouton "+" pour l'ajout d'un champion côté master écrase le texte écrit pour mon bouton côté detail et je ne sais pas pourquoi.
- Binding avec les images et icons fonctionnelles pour l'ajout d'un champion mais non fonctionnelle pour l'édition d'un champion avec le FilePicker.
## 👤 Author

**PERRET Louis**

* Github: [@LouisPerret](https://github.com/louis-perret)
* LinkedIn: [@Louis Perret](https://fr.linkedin.com/in/louis-perret-a67a6321b)