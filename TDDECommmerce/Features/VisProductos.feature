Feature: Visualización de Productos

  Como usuario
  Quiero poder ver una lista de productos dentro de cada categoría
  Para explorar los productos disponibles

  @CP_VP001 @Media
  Scenario: Visualización de productos dentro de una categoría
    Given que las categorías y productos están registrados en el sistema
    When accedo a la página de productos de una categoria
    Then debo ver una lista de productos con títulos, imágenes, descripciones, precios y la opción "Add to Cart"