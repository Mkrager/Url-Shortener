document.getElementById('addUrlForm').addEventListener('submit', async function (e) {
    e.preventDefault();

    const form = e.target;
    const formData = new FormData(form);

    try {
        const postResponse = await fetch('/ShortUrl/Create', {
            method: 'POST',
            body: formData
        });

        if (postResponse.ok) {
            closeAddUrlModal();
            form.reset();

            const getResponse = await fetch('/ShortUrl/List');

            if (getResponse.ok) {
                const urls = await getResponse.json();

                const tableBody = document.querySelector('#shortUrlTable tbody');
                tableBody.innerHTML = '';

                urls.forEach(shortUrl => {
                    const tr = document.createElement('tr');
                    tr.setAttribute('data-id', shortUrl.id);

                    let deleteButton = '';
                    if (shortUrl.createdBy == currentUserId || isAdmin) {
                        deleteButton = `<button class="btn btn-delete" onclick="deleteShortUrl('${shortUrl.id}')">Delete</button>`;
                    }

                    tr.innerHTML = `
                        <td class="name-cell" title="${shortUrl.originalUrl}">${shortUrl.originalUrl}</td>
                        <td>
                            <a href="https://localhost:7018/shortUrl/s/${shortUrl.shortCode}" target="_blank">
                                https://localhost:7018/shortUrl/s/${shortUrl.shortCode}
                            </a>
                        </td>
                        <td>
                            <div class="edit-actions">
                                ${deleteButton}
                            </div>
                        </td>
                    `;
                    tableBody.appendChild(tr);
                });
            } else {
                alert('Failed to refresh URL list.');
            }

        } else {
            const error = await postResponse.text();
            alert(error);
        }
    } catch (err) {
        console.error(err);
        alert('An error occurred while adding URL.');
    }
});
