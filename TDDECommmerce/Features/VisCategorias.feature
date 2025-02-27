Feature: Visualización de Categorías

  Como usuario
  Quiero poder ver una lista de categorías disponibles
  Para explorar los productos de cada categoría

  @VC001_1 @Alta
  Scenario: Visualización de lista de categorías
    Given que las categorías están registradas en el sistema
    When accedo a la página principal
    Then debo ver una lista de categorías con imágenes, descripciones y la opción "Show All"