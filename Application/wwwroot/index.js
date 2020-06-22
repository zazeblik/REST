async function loadBooks() {
    var response = await fetch("http://localhost:3000/api/books");
    
    if (response.ok) {
        var books = await response.json();
        renderTable(books);
    } else {
        alert("Ошибка HTTP: " + response.status);
    }
}

async function editBook() {
    var id = document.getElementById('editIdInput').value;
    if (!id) return;
    var title = document.getElementById('editTitleInput').value;
    var author = document.getElementById('editAuthorInput').value;
    const formData = new FormData();
    formData.append('title', title);
    formData.append('author', author);
    var response = await fetch("http://localhost:3000/api/books/" + id, {
        method: 'PUT',
        body: formData
    });
    if (response.ok) {
        await loadBooks();
    } else {
        alert("Ошибка HTTP: " + response.status);
    }
}

async function deleteBook() {
    var id = document.getElementById('deleteIdInput').value;
    if (!id) return;
    var response = await fetch("http://localhost:3000/api/books/" + id, {
        method: 'DELETE'
    });
    if (response.ok) {
        await loadBooks();
    } else {
        alert("Ошибка HTTP: " + response.status);
    }
}

async function addBook() {
    var title = document.getElementById('addTitleInput').value;
    if (!title) return;
    var author = document.getElementById('addAuthorInput').value;
    const formData = new FormData();
    formData.append('title', title);
    formData.append('author', author);
    var response = await fetch("http://localhost:3000/api/books", {
        method: 'POST',
        body: formData
    });
    if (response.ok) {
        await loadBooks();
    } else {
        alert("Ошибка HTTP: " + response.status);
    }
}

function renderTable(books) {
    var tableBody = document.getElementById('tableBody');
    tableBody.innerHTML = '';
    books.forEach(bookInfo => {
        var tr = document.createElement('tr');
        appendTd(bookInfo.id, tr);
        appendTd(bookInfo.title, tr);
        appendTd(bookInfo.author, tr);
        tableBody.appendChild(tr);
    });
}

function appendTd(data, tr) {
    var td = document.createElement('td');
    td.appendChild(document.createTextNode(data || ""));
    tr.appendChild(td);
}

loadBooks();