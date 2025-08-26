# Side Menu Implementation

## Overview
This document describes the implementation of the side menu navigation feature in the Customer Management System. The side menu provides easy access to key areas of the application and improves overall navigation.

## Features
- Responsive side menu that works on both desktop and mobile devices
- Clear visual feedback for the current active page
- Bootstrap Icons for improved visual hierarchy
- Collapsible on mobile devices

## Implementation Details

### 1. Side Menu Component
The side menu is implemented as a partial view (`_SideMenu.cshtml`) that can be included in any page:

```cshtml
<div class="sidebar">
    <div class="sidebar-sticky">
        <ul class="nav flex-column">
            <li class="nav-item">
                <a class="nav-link @(currentController == "Home" ? "active" : "")">
                    <i class="bi bi-speedometer2"></i>
                    Dashboard
                </a>
            </li>
            <!-- Other menu items -->
        </ul>
    </div>
</div>
```

### 2. Styling
The side menu uses custom CSS for styling and responsiveness:

```css
.sidebar {
    height: 100vh;
    width: 250px;
    position: fixed;
    background-color: #343a40;
    padding-top: 60px;
    color: white;
}
```

### 3. Layout Integration
The side menu is integrated into the main layout (`_Layout.cshtml`):

```cshtml
<partial name="_SideMenu" />
<div class="main-content">
    <main role="main" class="pb-3">
        @RenderBody()
    </main>
</div>
```

### 4. Mobile Responsiveness
On mobile devices (screen width < 768px), the side menu collapses:

```css
@media (max-width: 768px) {
    .sidebar {
        width: 0;
        overflow: hidden;
    }
    .main-content {
        margin-left: 0;
    }
}
```

## Navigation Structure
- Dashboard (`/Home/Index`)
  - Overview of customer metrics
  - Recent activity feed
- Customer List (`/Customer/Index`)
  - List of all customers
  - Customer management actions
- Settings (`/Settings/Index`)
  - Application configuration
  - User preferences

## Dependencies
- Bootstrap 5.x
- Bootstrap Icons 1.11.1
- ASP.NET Core 8.0

## Future Enhancements
1. Add animation for mobile menu toggle
2. Implement nested menu items for complex navigation
3. Add user preferences for menu customization
4. Implement menu state persistence