function openAboutModal() {
    document.getElementById("aboutModal").style.display = "flex";
}
function closeAboutModal() {
    document.getElementById("aboutModal").style.display = "none";
}

document.getElementById("aboutForm")?.addEventListener("submit", async (e) => {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);

    const response = await fetch('/aboutPage/Update', {
        method: 'PUT',
        body: formData
    });

    if (response.ok) {
        location.reload();
    } else {
        const error = await response.json();
        alert(error.error);
    }
});