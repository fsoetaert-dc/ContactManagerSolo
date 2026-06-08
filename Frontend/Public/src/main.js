//main menu buttons
const addContactButton = document.getElementById('addContactButton');
const contactListButton = document.getElementById('contactListButton');
const editContactButton = document.getElementById('editContactButton');
const deleteContactButton = document.getElementById('deleteContactButton');
const searchContactButton = document.getElementById('searchContactButton');
//addContact window
const addContactPopup = document.getElementById('addContactPopup');
const nameInputAdd = document.getElementById('nameInputAdd');
const telInputAdd = document.getElementById('telInputAdd');
const emailInputAdd = document.getElementById('emailInputAdd'); 
const createContactButton = document.getElementById('createContactButton');
const cancelAddContactButton = document.getElementById('cancelAddContactButton');
//confirmation window when contact is added
const addContactConfirmationPopup = document.getElementById('addContactConfirmationPopup');
const addContactOKButton = document.getElementById('addContactOKButton');
//contactList window
const contactListPopup = document.getElementById('contactListPopup');
const closeContactListButton = document.getElementById('closeContactListButton');
//editContactSearch window
const editContactSearchPopup = document.getElementById('editContactSearchPopup');
const IDInputSearchEdit = document.getElementById('IDInputSearchEdit');
const nameInputSearch = document.getElementById('nameInputSearch');
const searchContactButtonEdit = document.getElementById('searchContactButtonEdit');
const cancelSearchContactButtonEdit = document.getElementById('cancelSearchContactButtonEdit');
//editContact window
const editContactPopup = document.getElementById('editContactPopup');
const nameInputEdit = document.getElementById('nameInputEdit');
const telInputEdit = document.getElementById('telInputEdit');
const emailInputEdit = document.getElementById('emailInputEdit');
const editContactButtonEdit = document.getElementById('editContactButtonEdit');
const cancelEditContactButton = document.getElementById('cancelEditContactButton');
//confirmation window when contact is edited
const editContactConfirmationPopup = document.getElementById('editContactConfirmationPopup');
const editContactOKButton = document.getElementById('editContactOKButton');
//deleteContactSearch window
const deleteContactPopup = document.getElementById('deleteContactPopup');
const IDInputSearchDelete = document.getElementById('IDInputSearchDelete');
const deleteContactButtonDelete = document.getElementById('deleteContactButtonDelete');
const cancelDeleteContactButton = document.getElementById('cancelDeleteContactButton');
//deleteContactConfirmation window
const deleteContactConfirmationPopup = document.getElementById('deleteContactConfirmationPopup');
const deleteContactOKButton = document.getElementById('deleteContactOKButton');
//searchContact window
const searchContactPopup = document.getElementById('searchContactPopup');
const IDInputSearchSearch = document.getElementById('IDInputSearchSearch');
const searchContactButtonSearch = document.getElementById('searchContactButtonSearch');
const cancelSearchContactButtonSearch = document.getElementById('cancelSearchContactButtonSearch');
//foundContact window
const foundContactPopup = document.getElementById('foundContactPopup');
const closeFoundContactButton = document.getElementById('closeFoundContactButton');

//CONTACT TOEVOEGEN
//menu contact toevoegen -> contact toevoegen popup
addContactButton.addEventListener('click', () => {
    addContactPopup.style.display = 'block';
});
//contact toevoegen annuleren
cancelAddContactButton.addEventListener('click', () => {
    addContactPopup.style.display = 'none';
});
//contact aanmaken
createContactButton.addEventListener('click', () => {
    const contact = {
        name: nameInputAdd.value,
        tel: telInputAdd.value,
        email: emailInputAdd.value,
        id:  crypto.randomUUID()
    };
    localStorage.setItem('contact', JSON.stringify(contact));
    addContactConfirmationPopup.style.display = 'block';
});
//contact aangemaakt confirmation terug naar menu.
addContactOKButton.addEventListener('click', () => {
    addContactConfirmationPopup.style.display = 'none';
    addContactPopup.style.display = 'none';
});
//CONTACTENLIJST 
//menu toon contactenlijst -> contactenlijst popup
contactListButton.addEventListener('click', () => {
    contactListPopup.style.display = 'block';
});
//van contactenlijst terug naar menu
closeContactListButton.addEventListener('click', () => {
    contactListPopup.style.display = 'none';
});
//CONTACT AANPASSSEN
//menu contact aanpassen -> contact aanpassen popup
editContactButton.addEventListener('click', () => {
    editContactSearchPopup.style.display = 'block';
});
//contact aanpassen: zoeken annuleren
cancelSearchContactButtonEdit.addEventListener('click', () => {
    editContactSearchPopup.style.display = 'none';
});
//gevonden contact aanpassen
searchContactButtonEdit.addEventListener('click', () => {
    editContactPopup.style.display = 'block';
});
//gevonden contact verlaten
cancelEditContactButton.addEventListener('click', () => {
    editContactPopup.style.display = 'none';
});
//gevonden contact aangepast -> confirmation
editContactButtonEdit.addEventListener('click', () => {
    editContactConfirmationPopup.style.display = 'block';
});
//van confirmation terug naar menu
editContactOKButton.addEventListener('click', () => {
    editContactConfirmationPopup.style.display = 'none';
    editContactPopup.style.display = 'none';
    editContactSearchPopup.style.display = 'none';
});
//CONTACT VERWIJDEREN
//menu contact verwijderen -> contact zoeken opID voor verwijderen popup
deleteContactButton.addEventListener('click', () => {
    deleteContactPopup.style.display = 'block';
});
//contact verwijderen annuleren
cancelDeleteContactButton.addEventListener('click', () => {
    deleteContactPopup.style.display = 'none';
});
//contact verwijderen -> confirmation
deleteContactButtonDelete.addEventListener('click', () => {
    deleteContactConfirmationPopup.style.display = 'block';
});
//confirmation naar menu
deleteContactOKButton.addEventListener('click', () => {
    deleteContactConfirmationPopup.style.display = 'none';
    deleteContactPopup.style.display = 'none';
});
//CONTACT ZOEKEN
//menu contact zoeken -> contact zoeken op naam popup
searchContactButton.addEventListener('click', () => {
    searchContactPopup.style.display = 'block';
});
//contact zoeken annuleren
cancelSearchContactButtonSearch.addEventListener('click', () => {
    searchContactPopup.style.display = 'none';
});
//gevonden contacten weergeven
searchContactButtonSearch.addEventListener('click', () => {
    foundContactPopup.style.display = 'block';
});
//van gevonden contacten terug naar menu
//gevonden contacten weergeven
closeFoundContactButton.addEventListener('click', () => {
    foundContactPopup.style.display = 'none';
    searchContactPopup.style.display = 'none';
});