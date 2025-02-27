Feature: Inicio de Sesión

  Como usuario registrado
  Quiero poder iniciar sesión en el sistema
  Para acceder a mi cuenta y utilizar los servicios ofrecidos

  @INS001_1 @Alta
  Scenario: Inicio de sesión con credenciales válidas
    Given que el formulario de inicio de sesión está disponible
    When ingreso mi correo "user1@example.com" y contraseña "UserTest1234*"
    And inicio sesión
    Then el sistema debe autenticar al usuario

  @INS002_1 @Alta
  Scenario: Inicio de sesión con contraseña inválida
    Given que el formulario de inicio de sesión está disponible
    When ingreso mi correo "user1@example.com" y contraseña "User1"
    And inicio sesión
    Then el sistema no debe aceptar el inicio de sesión
    And se debe mostrar un mensaje de advertencia indicando que la contraseña ingresada es incorrecta: "Invalid Password"

  @INS003_1 @Alta
  Scenario: Inicio de sesión con usuario no registrado
    Given que el formulario de inicio de sesión está disponible
    When ingreso mi correo "user123@example.com" y contraseña "User123"
    And inicio sesión
    Then el sistema no debe aceptar el inicio de sesión
    And se debe mostrar un mensaje de advertencia indicando que el correo no ha sido registrado: "Invalid Email Or Username"

  @INS004_1 @Alta
  Scenario: Inicio de sesión inválido - Campos vacíos
    Given que el formulario de inicio de sesión está disponible
    When envío el formulario de inicio de sesion sin llenar los datos
    Then el sistema no debe aceptar el inicio de sesión
    And se debe mostrar un mensaje de advertencia indicando que los campos son obligatorios en el inicio de sesión:
      """
      The Email field is required.
      The Password field is required.
      """