function openAddUrlModal() {
    document.getElementById('addUrlModal').style.display = 'flex';
}

function closeAddUrlModal() {
    document.getElementById('addUrlModal').style.display = 'none';
}

window.onclick = function (event) {
    const modal = document.getElementById('addUrlModal');
    if (event.target === modal) {
        modal.style.display = 'none';
    }
}