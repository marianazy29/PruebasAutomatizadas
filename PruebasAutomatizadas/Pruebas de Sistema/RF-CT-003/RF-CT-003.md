# RF-CT-003: Validación de Campos Vacíos

## 📋 Descripción del Caso de Prueba

**Identificador:** RF-CT-003  
**Nombre:** Validación de Campos Vacíos  
**Técnica:** Particionamiento de Equivalencias - Datos Inválidos  
**Objetivo:** Verificar la validación cuando los campos requeridos están vacíos  
**Autor:** Neyber Rojas Zapata  

## 🎯 ¿Qué se va a probar?

Esta prueba automatizada valida que el formulario de contacto muestra mensajes de validación apropiados y bloquea el envío cuando los campos requeridos están vacíos.

### Condiciones de Prueba:
- **Formulario de contacto** con campos vacíos
- **Intento de envío** sin completar campos requeridos
- **Validación individual** de cada campo

### Particiones de Equivalencia - Datos Inválidos:
- **Nombre:** Campo vacío (cadena nula/vacía)
- **Apellido:** Campo vacío (cadena nula/vacía)
- **Email:** Campo vacío (sin formato de email)
- **Asunto:** Sin selección del dropdown
- **Mensaje:** Campo vacío (sin contenido)

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
RF-CT-003/
├── CamposVaciosTest.cs           # Clase principal de pruebas
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

### 3. Ejecutar Todas las Pruebas RF-CT-003
```bash
dotnet test --filter "RF_CT_003"
```

### 4. Ejecutar Solo la Prueba Principal
```bash
dotnet test --filter "RF_CT_003_ValidacionCamposVacios"
```

### 5. Ejecutar Validación Individual de Campos
```bash
dotnet test --filter "RF_CT_003_ValidacionCamposIndividuales"
```

### 6. Ejecutar con Salida Detallada
```bash
dotnet test --filter "RF_CT_003" --logger "console;verbosity=detailed"
```

## 📊 Evidencias de Ejecución

### ✅ Ejecución Exitosa - 19 de Agosto 2025

#### Prueba Principal (RF_CT_003_ValidacionCamposVacios)
```
Restore complete (0.7s)                                                                                                
  PruebasAutomatizadas succeeded (0.2s) → bin/Debug/net9.0/PruebasAutomatizadas.dll                                    
  PruebasAutomatizadas test succeeded (103.8s)                                                                         

Test summary: total: 6, failed: 0, succeeded: 6, skipped: 0, duration: 103.0s
Build succeeded in 105.1s
```

#### Todas las Pruebas RF-CT-003 con Salida Detallada
```
Restore complete (0.5s)                                                                                                
  PruebasAutomatizadas succeeded (0.3s) → bin/Debug/net9.0/PruebasAutomatizadas.dll                                    
  PruebasAutomatizadas test succeeded (70.1s)                                                                          

Test summary: total: 6, failed: 0, succeeded: 6, skipped: 0, duration: 69.9s
Build succeeded in 71.3s
```

### 📝 Salida de Consola de la Prueba

```
=== RF-CT-003: Validación de Campos Vacíos ===
Submit button clicked with empty fields
✓ Form submission blocked - still on contact page
✓ Input validation detected: Required field
✓ Input validation detected: Please fill out this field
✓ Input validation detected: Please enter an email address
✓ RF-CT-003 PASSED: Form validation working correctly for empty fields

=== RF-CT-003: Validación Individual de Campos ===
Testing field: First name
  ✓ Validation detected for First name: Please fill out this field
Testing field: Last name  
  ✓ Validation detected for Last name: Please fill out this field
Testing field: Email
  ✓ Validation detected for Email: Please enter an email address
Testing field: Your message
  ✓ Validation detected for Your message: Please fill out this field
```

### 🔍 Resultados de Validación Detectados

La prueba RF-CT-003 confirmó exitosamente:

1. **✅ El envío no procede** - El formulario permanece en la página de contacto
2. **✅ Mensajes de validación específicos mostrados:**
   - "Please fill out this field" para campos de texto
   - "Please enter an email address" para campo email
   - Validación HTML5 nativa activada
3. **✅ Campos marcados como requeridos** - Atributos `required` detectados
4. **✅ Validación individual funciona** - Focus/blur activa validación por campo
5. **✅ Estados ARIA configurados** - `aria-invalid="true"` aplicado

## 🧪 Casos de Prueba Incluidos

### 1. RF_CT_003_ValidacionCamposVacios (Principal)
- **Propósito:** Validar que el formulario bloquea el envío con campos vacíos
- **Escenario:** Intentar enviar formulario sin llenar ningún campo
- **Validaciones:**
  - El envío no procede ✅
  - Se permanece en la página de contacto ✅
  - Mensajes de validación específicos mostrados ✅
  - Campos marcados como requeridos ✅

### 2. RF_CT_003_ValidacionCamposIndividuales (Auxiliar)
- **Propósito:** Probar validación individual de cada campo
- **Escenario:** Focus/blur en cada campo sin contenido
- **Validaciones:**
  - Validación HTML5 activada ✅
  - Atributos aria-invalid configurados ✅
  - Mensajes de validación por campo ✅

## 📊 Resultados Esperados

### ✅ Comportamiento Esperado:
1. **El envío no procede** cuando hay campos vacíos
2. **Mensajes de validación específicos** son mostrados
3. **Campos marcados como requeridos** visualmente
4. **Permanece en la página de contacto** (no hay redirección)
5. **Validación HTML5** funciona correctamente

### 🔍 Indicadores de Validación:
- Mensajes de error visibles (`.invalid-feedback`, `.error`, `.text-danger`)
- Atributos HTML5 (`required`, `validationMessage`)
- Estados ARIA (`aria-invalid="true"`)
- Clases CSS de error aplicadas

## 🔧 Características Técnicas

### Detección de Validación
- ✅ **Múltiples selectores** para mensajes de error
- ✅ **Validación HTML5** nativa del navegador
- ✅ **Atributos ARIA** para accesibilidad
- ✅ **Estados visuales** de campos inválidos

### Manejo de Angular SPA
- ✅ **Espera dinámica** para carga de elementos
- ✅ **Eventos focus/blur** para activar validación
- ✅ **Detección robusta** de estados de validación

### Gestión de Navegador
- ✅ **Limpieza automática** de procesos Chrome
- ✅ **Configuración optimizada** para estabilidad
- ✅ **Timeouts apropiados** para validación

## 🐛 Solución de Problemas

### No se Detectan Mensajes de Validación
- Verificar que los campos tengan atributo `required`
- Comprobar si usa validación HTML5 o JavaScript personalizada
- Revisar selectores CSS para mensajes de error

### Validación No se Activa
- Asegurar que se hace focus/blur en los campos
- Verificar que Angular ha cargado completamente
- Comprobar eventos de validación del formulario

### Formulario se Envía con Campos Vacíos
- Verificar que la validación client-side está habilitada
- Comprobar JavaScript de validación personalizada
- Revisar configuración del formulario Angular

## 📈 Métricas de Rendimiento

### Métricas Reales de Ejecución:
- **Tiempo de ejecución prueba principal:** 103.8 segundos
- **Tiempo de ejecución todas las pruebas:** 70.1 segundos
- **Tiempo de compilación:** ~0.3 segundos
- **Tiempo de carga Angular:** ~5 segundos
- **Tiempo de validación:** Inmediata (HTML5 nativa)
- **Detección de errores:** <1 segundo

### Estadísticas de Pruebas:
- **Total de pruebas ejecutadas:** 6
- **Pruebas exitosas:** 6 (100%)
- **Pruebas fallidas:** 0
- **Pruebas omitidas:** 0
- **Duración total:** 69.9-103.0 segundos

## 🔄 Mantenimiento

### Actualización de Selectores de Error
Si cambian los mensajes de validación, actualizar:
```csharp
var errorMessages = driver.FindElements(By.CssSelector(
    ".invalid-feedback, .error, .text-danger, [class*='error']"));
```

### Nuevos Campos de Validación
Para agregar validación de nuevos campos:
```csharp
// Agregar al método RF_CT_003_ValidacionCamposIndividuales
var newField = driver.FindElement(By.Id("new-field"));
// Aplicar lógica de validación
```
