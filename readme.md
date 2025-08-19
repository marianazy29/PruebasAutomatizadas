# Proyecto Final del Módulo 6
# Plataforma de testing: https://practicesoftwaretesting.com


# Módulo de Login

## 1. Requerimientos

### 1.1 Funcionales
- El sistema debe permitir que un usuario registrado ingrese su correo electrónico y contraseña en el formulario de login.
- Al hacer clic en el botón login, el sistema debe autenticar los datos contra la base de usuarios.
- Si las credenciales son correctas, el usuario debe ser redirigido al dashboard o área protegida según su rol.
- Validar campos obligatorios, formato de email y longitud mínima y máxima de password.
  
### 1.2 No funcionales
- El sistema debe procesar la autenticación de un usuario válido en un tiempo máximo de 3 segundos bajo condiciones normales.
- El tiempo de respuesta se mide desde el envío de la solicitud de login hasta la carga completa del dashboard.
- Bajo carga concurrente, el 95% de los logins exitosos debe cumplirse en ≤ 3 segundos.
- La funcionalidad debe garantizar seguridad básica ante intentos fallidos repetidos.

## 2. Casos de Prueba Resumidos

| **ID** | **Qué probar** | **Tipo** | **Datos de entrada** | **Resultado esperado** |
|--------|----------------|----------|--------------------|----------------------|
| CP-RF-LG-01 | Login exitoso | Funcional | Usuario válido (`admin@practicesoftwaretesting.com / welcome01`) | Redirección al dashboard |
| CP-RF-LG-02 | Login fallido contraseña incorrecta | Funcional | Usuario válido / contraseña incorrecta | Mensaje “Invalid email or password” |
| CP-RF-LG-03 | Login fallido usuario inexistente | Funcional | Usuario inexistente | Mensaje “Invalid email or password” |
| CP-RF-LG-04 | Validación de campos obligatorios y formato | Funcional | Campos vacíos o email/contraseña inválidos | Mensajes de error según campo |
| CP-RNF-LG-01 | Tiempo de respuesta individual | No funcional | Usuario válido | ≤ 3 segundos |
| CP-RNF-LG-02 | Tiempo de respuesta bajo carga | No funcional | 10 usuarios concurrentes | 95% logins ≤ 3 segundos |
| CP-RNF-LG-03 | Tiempo de respuesta end-to-end en UI | No funcional | Usuario válido en navegador | Dashboard cargado ≤ 3 segundos |

## 3. Ejecución de Pruebas Automatizadas (C#)

a. **Configurar proyecto**:
   - Crear proyecto Console App o Test Project en Visual Studio (.NET).
   - Instalar paquetes NuGet:  
     ```
     Microsoft.Playwright
     Selenium.WebDriver
     Selenium.Support
     ```
   - Instalar navegadores de Playwright:
     ```
     playwright install
     ```

b. **Escribir código de prueba**:
   - Se automatizan los casos funcionales: login exitoso, login fallido, usuario inexistente y validación de campos.
   - Se verifican mensajes de error y redirección al dashboard.
   - Permite ejecución visual (`Headless = false`) para seguimiento en tiempo real.

c. **Ejecutar pruebas de rendimiento y carga**:
   - Usar **Insomnia** para pruebas individuales de API y medir tiempo de respuesta.
   - Usar **Apache JMeter** para pruebas de carga con múltiples usuarios concurrentes.
   - Registrar métricas y comparar con los límites de tiempo esperados (≤ 3 segundos).

d. **Ejecutar pruebas**:
   - Ejecutar desde Visual Studio o consola.
   - Observar resultados en consola y/o reportes de Playwright.

**Prueba de API vía Insomnia**
![API Insomnia](/PruebasAutomatizadas/docs/api-insomnia.png)

Ejecutar:
```
dotnet test --filter "ClassName=LoginTestExitoUsuarioValido" 
```
Resultado:
![LoginTestExitoUsuarioValido](/PruebasAutomatizadas/docs/logintestexitousuariovalido.png)

Ejecutar:
```
dotnet test --filter "ClassName=LoginTestFallidoContrasenaIncorrecta" 
```
Resultado:
![LoginTestFallidoContrasenaIncorrecta](/PruebasAutomatizadas/docs/logintestfallidocontrasenaincorrecta.png)

Ejecutar:
```
dotnet test --filter "ClassName=LoginTestFallidoUsuarioInexistente" 
```
Resultado:
![LoginTestFallidoUsuarioInexistente](/PruebasAutomatizadas/docs/logintestfallidousuarioinexistente.png)

Ejecutar:
```
dotnet test --filter "ClassName=LoginTestUsuarioValidoPlaywright" 
```
Resultado:
![LoginTestUsuarioValidoPlaywright](/PruebasAutomatizadas/docs/logintestusuariovalidoplaywright.png)

Ejecutar:
```
dotnet test --filter "ClassName=LoginTestValidacionCamposObligatorios" 
```
Resultado:
![LoginTestValidacionCamposObligatorios](/PruebasAutomatizadas/docs/logintestvalidacioncamposobligatorios.png)

Ejecutar:
```
dotnet test --filter "ClassName=LoginTestValidacionEmail" 
```
Resultado:
![LoginTestValidacionEmail](/PruebasAutomatizadas/docs/logintestvalidacionemail.png)

Ejecutar:
```
dotnet test --filter "ClassName=LoginTestValidacionLongitudPassword" 
```
Resultado:
![LoginTestValidacionLongitudPassword](/PruebasAutomatizadas/docs/logintestvalidacionlongitudpassword.png)

**JMeter - Test Plain - Prueba de concurrencia de usuarios.**
![Jmeter1](/PruebasAutomatizadas/docs/jmeter1.png)
![Jmeter2](/PruebasAutomatizadas/docs/jmeter2.png)
![Jmeter3](/PruebasAutomatizadas/docs/jmeter3.png)
![Jmeter4](/PruebasAutomatizadas/docs/jmeter4.png)
![Jmeter5](/PruebasAutomatizadas/docs/jmeter5.png)

### Nota
- Esta documentación resume los requisitos, casos de prueba y guía de automatización.  
- Para detalles completos de cada escenario, mensajes exactos y pasos de ejecución manual, ver plan de pruebas completo en el informe final.
