import { pack } from 'msgpackr';
import { compress } from 'brotli';

const synchWithApi = async (endpoint: string, payload: any[]) => {
	const apiBase = "https://api.campabuc.com";
	const address = `${apiBase}/${endpoint}/sync`;
	const msgPack = pack(payload);
	const brData = compress(msgPack, {
		mode: 0,           // generic
		quality: 6,        // 0–11 (balance speed vs size)
		lgwin: 22,         // sliding window size (default 22)
	})
	await fetch(address, {
		method: 'POST', headers: { 'Content-Type': 'application/x-msgpack', 'Content-Encoding': 'br' },
		body: brData
	});
}

export default synchWithApi;

