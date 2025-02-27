Feature: Registro de Usuarios

  Como usuario nuevo
  Quiero poder registrarme en el sistema
  Para poder acceder a los servicios ofrecidos

  @CP-01 @Alta
  Scenario: Registro de usuarios válidos
    Given que el formulario de registro está disponible
    When ingreso mi nombre "Usuario1", apellido "Prueba", correo "user1@example.com", contraseña "UserTest1234*" y confirmo la contraseña "UserTest1234*"
    And envío el formulario
    Then el sistema debe aceptar el registro

  @CP-02 @Alta
  Scenario: Registro de usuarios inválidos - contraseña inválida
    Given que el formulario de registro está disponible
    When ingreso mi nombre "Usuario2", apellido "Prueba", correo "user2@example.com", contraseña "User2" y confirmo la contraseña "User2"
    And envío el formulario
    Then el sistema no debe aceptar el registro
    And se debe mostrar un mensaje de advertencia indicando el formato esperado de contraseña:
      """
      Passwords must be at least 6 characters.
      Passwords must have at least one non alphanumeric character.
      """

  @CP-03 @Alta
  Scenario: Registro de usuarios inválidos - contraseña no coincide con la confirmación
    Given que el formulario de registro está disponible
    When ingreso mi nombre "Usuario3", apellido "Prueba", correo "user3@example.com", contraseña "User2" y confirmo la contraseña "User"
    And envío el formulario
    Then el sistema no debe aceptar el registro
    And se debe mostrar un mensaje de advertencia indicando que las contraseñas no coinciden:
      """
      'ConfirmPassword' and 'Password' do not match.
      """

  @CP-04 @Alta
  Scenario: Registro de usuarios inválidos - Campos vacíos
    Given que el formulario de registro está disponible
    When envío el formulario sin llenar los datos
    Then el sistema no debe aceptar el registro
    And se debe mostrar un mensaje de advertencia indicando que los campos son obligatorios:
      """
      The First Name field is required.
      The Last Name field is required.
      The Email field is required.
      The Password field is required.
      The ConfirmPassword field is required.
      """