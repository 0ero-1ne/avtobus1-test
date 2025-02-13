document.querySelector("#input-link").addEventListener("input", (event) => {
	const regex = /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)/gm;
	let link = "" + event.target.value;

	if (regex.test(link.trim())) {
		document.querySelector("#submit-link").removeAttribute("disabled");
		document.querySelector("#input-link").classList.remove("border-danger");
	} else {
		document.querySelector("#submit-link").setAttribute("disabled", "");
		document.querySelector("#input-link").classList.add("border-danger");
	}
})