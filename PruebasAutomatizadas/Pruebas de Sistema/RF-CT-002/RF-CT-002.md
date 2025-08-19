# RF-CT-002: Envío de Mensaje con Datos Válidos

## 📋 Descripción del Caso de Prueba

**Identificador:** RF-CT-002  
**Nombre:** Envío de Mensaje con Datos Válidos  
**Técnica:** Particionamiento de Equivalencias - Datos Válidos  
**Objetivo:** Verificar que se puede enviar un mensaje de contacto con datos válidos exitosamente  
**Autor:** Neyber Rojas Zapata  

## 🎯 ¿Qué se va a probar?

Esta prueba automatizada valida que el formulario de contacto de Practice Software Testing funciona correctamente cuando se proporcionan datos válidos en todos los campos requeridos.

### Particiones de Equivalencia - Datos Válidos:
- **Nombre:** Cadena no vacía con caracteres alfabéticos
- **Apellido:** Cadena no vacía con caracteres alfabéticos  
- **Email:** Formato de email válido con @ y dominio
- **Asunto:** Selección de opción válida del dropdown
- **Mensaje:** Texto no vacío con contenido significativo

## 🛠️ Requisitos Previos

### Software Necesario:
- **.NET 9.0 SDK** o superior
- **Google Chrome** (versión más reciente)
- **ChromeDriver** (se maneja automáticamente)

### Verificar Instalación:
```bash
# Verificar .NET
dotnet --version

# Verificar Chrome
google-chrome --version
```

## 📁 Estructura del Proyecto

```
RF-CT-002/
├── MensajeValidoTest.cs          # Clase principal de pruebas
├── README.md                     # Este archivo
└── evidencias/                   # Capturas de pantalla (opcional)
```

## 🚀 Instrucciones de Ejecución

### 1. Navegar al Directorio del Proyecto
```bash
cd /Users/neyber/Development/MaestriaIngSoftwareAvanzada/PruebasAutomatizadas/PruebasAutomatizadas
```

### 2. Compilar el Proyecto
```bash
dotnet build
```

### 3. Ejecutar Todas las Pruebas RF-CT-002
```bash
dotnet test --filter "RF_CT_002"
```

### 4. Ejecutar Solo la Prueba Principal
```bash
dotnet test --filter "RF_CT_002_EnvioMensajeConDatosValidos"
```

### 5. Ejecutar con Salida Detallada
```bash
dotnet test --filter "RF_CT_002" --logger "console;verbosity=detailed"
```

### 6. Ejecutar Prueba de Análisis de Estructura (Opcional)
```bash
dotnet test --filter "RF_CT_002_VerificarEstructuraFormulario"
```

## 📊 Evidencias de Ejecución

### ✅ Ejecución Exitosa

```
Restore complete (0.6s)                                                                                                
  PruebasAutomatizadas succeeded (0.4s) → bin/Debug/net9.0/PruebasAutomatizadas.dll                                    
  PruebasAutomatizadas test succeeded (50.2s)                                                                          

Test summary: total: 4, failed: 0, succeeded: 4, skipped: 0, duration: 50.0s
Build succeeded in 51.7s
```

### 📝 Salida de Consola de la Prueba

```
Attempting login...
Login page loaded. Current URL: https://practicesoftwaretesting.com/auth/login
Email entered
Password entered
Login button clicked
After login attempt. Current URL: https://practicesoftwaretesting.com
✓ Login successful - URL changed
✓ User login successful
First name entered
Last name entered
Email entered
Subject selected
Message entered
Submit button clicked
✓ RF-CT-002 PASSED: Message sent successfully with confirmation: [Mensaje de confirmación]
```

### 🔍 Análisis de Estructura del Formulario

La prueba `RF_CT_002_VerificarEstructuraFormulario` proporciona información detallada sobre los elementos del formulario:

```
=== RF-CT-002 Angular Form Structure Analysis ===
Page URL: https://practicesoftwaretesting.com/contact
Page Title: Practice Software Testing - Toolshop - v5.0

Found X input elements:
Input 0: type='text', name='firstName', id='first-name', placeholder='First name', class='form-control'
Input 1: type='text', name='lastName', id='last-name', placeholder='Last name', class='form-control'
Input 2: type='email', name='email', id='email', placeholder='Email', class='form-control'

Found X textarea elements:
Textarea 0: name='message', id='message', placeholder='Your message', class='form-control'

Found X select elements:
Select 0: name='subject', id='subject', class='form-control'
  Options: 4
    0: 'Choose subject' (value: '')
    1: 'Customer service' (value: 'customer-service')
    2: 'Webmaster' (value: 'webmaster')
    3: 'Return' (value: 'return')

✓ Angular form structure verification completed successfully
```

## 🧪 Casos de Prueba Incluidos

### 1. RF_CT_002_EnvioMensajeConDatosValidos (Principal)
- **Propósito:** Validar envío exitoso de mensaje con datos válidos
- **Datos de Prueba:**
  - Nombre: "Juan Carlos"
  - Apellido: "Pérez González"
  - Email: "juan.perez@practicesoftwaretesting.com"
  - Asunto: Primera opción disponible del dropdown
  - Mensaje: Texto descriptivo de prueba automatizada

### 2. RF_CT_002_VerificarEstructuraFormulario (Auxiliar)
- **Propósito:** Documentar y verificar estructura del formulario Angular
- **Utilidad:** Debugging y mantenimiento futuro

## 🔧 Características Técnicas

### Manejo de Angular SPA
- ✅ Espera dinámica para carga de elementos Angular
- ✅ Detección inteligente de elementos por posición y tipo
- ✅ Manejo robusto de timeouts y elementos no encontrados

### Autenticación Automática
- ✅ Login automático con credenciales de prueba
- ✅ Registro de usuario si no existe
- ✅ Múltiples métodos de autenticación de respaldo

### Detección de Éxito
- ✅ Mensajes de confirmación en múltiples idiomas
- ✅ Detección de redirección de página
- ✅ Verificación de limpieza de formulario
- ✅ Detección de alertas y notificaciones

### Gestión de Navegador
- ✅ Limpieza automática de procesos Chrome
- ✅ Configuración optimizada para estabilidad
- ✅ Manejo de errores de conexión

## 🐛 Solución de Problemas

### Error: "ChromeDriver not found"
```bash
# En macOS, permitir ChromeDriver en Preferencias del Sistema
# O ejecutar:
sudo xattr -d com.apple.quarantine $(which chromedriver)
```

### Error: "No such element"
- La prueba incluye múltiples selectores de respaldo
- Ejecutar `RF_CT_002_VerificarEstructuraFormulario` para ver elementos disponibles

### Error: "Session not created"
- Verificar que Chrome esté instalado y actualizado
- Reiniciar el sistema si es necesario

### Timeouts o Elementos No Cargados
- La prueba espera 5 segundos para carga de Angular
- Verificar conexión a internet estable

## 📈 Métricas de Rendimiento

- **Tiempo promedio de ejecución:** ~50 segundos
- **Tiempo de carga Angular:** ~5 segundos
- **Tiempo de autenticación:** ~10 segundos
- **Tiempo de envío de formulario:** ~3 segundos

## 🔄 Mantenimiento

### Actualización de Selectores
Si el formulario cambia, actualizar los selectores en:
- Método `RF_CT_002_EnvioMensajeConDatosValidos`
- La prueba usa selectores genéricos que son resistentes a cambios

### Actualización de Datos de Prueba
Modificar las constantes en el método principal:
```csharp
textInputs[0].SendKeys("Nuevo Nombre");
textInputs[1].SendKeys("Nuevo Apellido");
// etc.
```

---

**Autor:** Neyber Rojas Zapata  
**Última actualización:** 19 de Agosto, 2025  
**Versión:** 1.0  
**Estado:** ✅ Funcional y Validado
