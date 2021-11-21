import { UIRouter } from "@uirouter/core";

/** UIRouter Config  */
export function uiRouterConfigFn(router: UIRouter) {
  router.urlService.rules.initial({ state: "list" });
}
