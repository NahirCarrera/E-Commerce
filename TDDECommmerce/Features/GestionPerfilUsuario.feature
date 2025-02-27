Feature: Gestión de Perfil de Usuario

  Como usuario registrado
  Quiero poder editar mi perfil
  Para mantener mi información actualizada

  @GPU001_1 @Media
  Scenario: Edición de perfil de usuario válido
    Given que he iniciado sesión en el sistema
    And accedo a la sección de perfil
    When edito el campo username con "TestUser"
    And guardo los cambios
    Then el perfil debe mostrarse con los nuevos datos

  @GPU002_1 @Media
  Scenario: Edición de perfil de usuario inválido - Campos vacíos
    Given que he iniciado sesión en el sistema
    And accedo a la sección de perfil
    When elimino la información del campo username
    And guardo los cambios
    Then se debe mostrar un mensaje de advertencia indicando que el campo es requerido: "The Username field is required."