// Side Menu Toggle functionality
document.addEventListener('DOMContentLoaded', function () {
    const sidebarToggle = document.getElementById('sidebarToggle');
    const sidebar = document.querySelector('.sidebar');
    
    // Toggle sidebar on button click
    if (sidebarToggle) {
        sidebarToggle.addEventListener('click', function () {
            sidebar.classList.toggle('collapsed');
            
            // Store the state in localStorage
            const isCollapsed = sidebar.classList.contains('collapsed');
            localStorage.setItem('sidebarCollapsed', isCollapsed);
        });
    }
    
    // Restore sidebar state on page load
    const savedState = localStorage.getItem('sidebarCollapsed');
    if (savedState === 'true') {
        sidebar.classList.add('collapsed');
    }
    
    // Handle responsive behavior
    function handleResize() {
        if (window.innerWidth <= 768) {
            sidebar.classList.add('collapsed');
        }
    }
    
    window.addEventListener('resize', handleResize);
    handleResize(); // Initial check
});