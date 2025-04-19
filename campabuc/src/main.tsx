import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import { initializeApp } from './lib/init';
import { ThemeProvider } from "./theme/themeprovider";

initializeApp().then(() => {
	ReactDOM.createRoot(document.getElementById('root')! as HTMLElement).render(
		<React.StrictMode>
			<ThemeProvider><App /></ThemeProvider>
		</React.StrictMode>
	);
});



