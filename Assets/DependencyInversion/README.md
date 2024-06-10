* LeaderboardController sınıfının LeaderboardSorterByScore ve LeaderboardSorterByName sınıflarına olan bağımlılığı
  kaldırılmak istenmektedir. Dependency Inversion prensibine göre çözümleyiniz.

* Eksik gördüğünüz başka alanları tasarım desenleri ve prensiplerini kullanarak iyileştiriniz.
  /n
*
*
* Summary

    * Introduced ILeaderboardSorter interface.

    * Refactored LeaderboardSorterByName and LeaderboardSorterByScore to implement ILeaderboardSorter.

    * Updated LeaderboardController to use ILeaderboardSorter.

    * Adjusted LeaderboardView to initialize LeaderboardController with the appropriate sorter.

    * This refactor adheres to the Dependency Inversion Principle, making the LeaderboardController more flexible and
      easier to extend or maintain. 