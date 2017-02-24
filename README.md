NBitcoin.SimpleVerificationServer
=================================

Provides payment verification services using simplified payment verification (SPV), 
instead of a full node, based on NBitcoin.


**NOTE** This project is only in extreme pre-alpha stage, pretty much nothing more
than an idea.

It doesn't even have a reference to NBitcoin yet!

Currently the code does absolutely nothing, but here is the plan...


Basic idea is:

* Server that connects to the network and has an SPV wallet

* JSON-RPC that supports the ImportAddress and ListUnspent commands

* Client can import watch-only addresses

* Transactions tracked and verified via SPV

* ListUnspent returns the results.


Basically, just a barely sufficient watch-only wallet, running as a service, that
can be used to track/verify payments (to generated addresses).

Will have to see how far I get :-)


