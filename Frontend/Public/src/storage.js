const storageKey = "contactlist";

//read the list
export function loadContacts() {
  const json = localStorage.getItem(storageKey);
  return json ? JSON.parse(json) : [];
}

//save the list
export function saveContacts(contacts) {
  localStorage.setItem(storageKey, JSON.stringify(contacts));
}

//add contact
export function addContact(contact){
    contactList = loadContacts();
    contactList.push(contact);
    saveContacts();
}